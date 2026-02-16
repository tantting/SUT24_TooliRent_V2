using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using SUT24_TooliRent_V2_Application.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using LoginDto = SUT24_TooliRent_V2.AuthDtos.LoginDto;
using RegisterDto = SUT24_TooliRent_V2.AuthDtos.RegisterDto;

namespace SUT24_TooliRent_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // private readonly UserManager<IdentityUser> _userManager; // or your IUserService
        // private readonly SignInManager<IdentityUser> _signInManager;
        // private readonly IConfiguration _config;
        
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            // _userManager = users;
            // _signInManager = signInManager;
            // _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto, CancellationToken ct)
        {
            var result = await _authService.RegisterAsync(dto, ct);
            
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto,  CancellationToken ct)
        {
            var token = await _authService.LoginAsync(dto, ct);
            if (token == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(new { Token = token });
        }
        
       //Generate new JWT Token
       [HttpPost("refresh-token")]
       public async Task<IActionResult> RefreshToken([FromBody] string refreshToken, CancellationToken ct)
       {
           var token = await _authService.RefreshTokenAsync(refreshToken, ct);

           if (token == null)
           {
               return Unauthorized("Invalid refreshToken"); 
           }

           return Ok(new { Token = token });
       }
    }
}
