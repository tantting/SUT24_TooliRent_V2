using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SUT24_TooliRent_V2.AuthDtos;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SUT24_TooliRent_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly AuthDbContext _authDb;

        public AuthController(UserManager<IdentityUser> users, SignInManager<IdentityUser> signInManager,
            IConfiguration config, AuthDbContext authDb)
        {
            _userManager = users;
            _signInManager = signInManager;
            _config = config;
            _authDb = authDb;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Member");
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return Unauthorized("Invalid login attempt");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid login attempt");

            var accessToken = await GenerateJwtToken(user);
            var refreshToken = await CreateRefreshTokenAsync(user.Id);

            return Ok(new { accessToken, refreshToken });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshDto dto)
        {
            var stored = await _authDb.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == dto.RefreshToken && !t.IsRevoked);

            if (stored != null)
            {
                stored.IsRevoked = true;
                await _authDb.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshDto dto)
        {
            var stored = await _authDb.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == dto.RefreshToken);

            if (stored == null || stored.IsRevoked || stored.ExpiresAt < DateTime.UtcNow)
                return Unauthorized("Invalid or expired refresh token");

            var user = await _userManager.FindByIdAsync(stored.UserId);
            if (user == null) return Unauthorized("User not found");

            stored.IsRevoked = true;
            var newRefreshToken = await CreateRefreshTokenAsync(user.Id);
            await _authDb.SaveChangesAsync();

            var accessToken = await GenerateJwtToken(user);

            return Ok(new { accessToken, refreshToken = newRefreshToken });
        }

        private async Task<string> CreateRefreshTokenAsync(string userId)
        {
            var token = new RefreshToken
            {
                UserId = userId,
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
            _authDb.RefreshTokens.Add(token);
            await _authDb.SaveChangesAsync();
            return token.Token;
        }

        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:DurationInMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
