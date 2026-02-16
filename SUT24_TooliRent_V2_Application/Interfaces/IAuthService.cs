using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;

namespace SUT24_TooliRent_V2_Application.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterRequestDto requestDto, CancellationToken ct);
    Task<string?> LoginAsync(LoginRequestDto requestDto, CancellationToken ct);
    Task<string?> RefreshTokenAsync(string token, CancellationToken ct);
}