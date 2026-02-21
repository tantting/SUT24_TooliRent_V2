using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using SUT24_TooliRent_V2_Application.Interfaces;


namespace SUT24_TooliRent_V2_Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMemberLookup _memberLookup;
    
    public AuthService(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
       IJwtTokenService jwtTokenService,
        IMemberLookup memberLookup)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _memberLookup = memberLookup;
    }
    public async Task<IdentityResult> RegisterAsync(RegisterRequestDto requestDto, CancellationToken ct)
    {
        var existing = await _userManager.FindByEmailAsync(requestDto.Email);
        if (existing != null)
            return IdentityResult.Failed(new IdentityError { Description = "Email already registered"});

        var user = new IdentityUser
        {
            UserName = requestDto.Email,
            Email = requestDto.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, requestDto.Password);
        
        if (!result.Succeeded)
        {
            return result;
        }

        // Default role: "Member"
        await _userManager.AddToRoleAsync(user, "Member");

        return IdentityResult.Success;
    }
    
    //Login method generating a token
    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto requestDto, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(requestDto.Email);
        if (user == null)
        {
            return null;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, requestDto.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            return null; 
        }

        var roles = await _userManager.GetRolesAsync(user);

        var member = await _memberLookup.GetByIdentityUserIdAsync(user.Id, ct); 

        var authUser = new AuthUserDto
        {
            UserId = user.Id,
            Email = user.Email!,
            FirstName = member?.FirstName ?? string.Empty,
            LastName = member?.LastName ?? string.Empty,
            Roles = roles.ToList()
        };

        var tokenResult = await _jwtTokenService.GenerateTokenAsync(authUser);
        
        //Generate JWT
        return new AuthResponseDto
        {
            AccessToken = tokenResult.AccessToken,
            AccessTokenExpiredAtUtc = tokenResult.ExpiresAtUtc
        };
    }

    public async Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto, CancellationToken ct)
    {
        var principal = _jwtTokenService.GetPrincipalFromExpiredToken(dto.RefreshToken);
        if (principal == null)
            return null;

        var email = principal.FindFirstValue(ClaimTypes.Email);
        if (email == null)
            return null;

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return null;

        var roles = await _userManager.GetRolesAsync(user);

        var member = await _memberLookup.GetByIdentityUserIdAsync(user.Id, ct);
        if (member == null)
            return null;

        var authUser = new AuthUserDto
        {
            UserId = user.Id,
            Email = user.Email!,
            FirstName = member.FirstName,
            LastName = member.LastName,
            Roles = roles.ToList()
        };

        var tokenResult = await _jwtTokenService.GenerateTokenAsync(authUser);

        return new AuthResponseDto
        {
            AccessToken = tokenResult.AccessToken,
            AccessTokenExpiredAtUtc = tokenResult.ExpiresAtUtc
        };
    }
}