using System.Runtime.InteropServices.JavaScript;

namespace SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;

public record AuthResponseDto
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init;} = string.Empty;
    public DateTime AccessTokenExpiredAtUtc { get; init; }
}