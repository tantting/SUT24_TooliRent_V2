using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using SUT24_TooliRent_V2_Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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

        var accessToken = await _jwtTokenService.GenerateTokenAsync(authUser);

        var refreshToken = Guid.NewGuid().ToString(); 
        
        //Generate JWT
        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpiredAtUtc = DateTime.UtcNow.AddMinutes(_jwtTokenService.DurationInMinutes)
        }); 
    }

    public Task<string?> RefreshTokenAsync(string token, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RevokeRefreshTokenAsync(Guid refreshTokenId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}