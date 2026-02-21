using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;

namespace SUT24_TooliRent_V2_Application.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterRequestDto requestDto, CancellationToken ct);
    Task<AuthResponseDto?> LoginAsync(LoginRequestDto requestDto, CancellationToken ct);
    Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto, CancellationToken ct);
}