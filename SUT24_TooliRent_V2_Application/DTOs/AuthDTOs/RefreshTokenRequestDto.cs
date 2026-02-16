namespace SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;

public record RefreshTokenRequestDto
{
public string RefreshToken { get; init; } = string.Empty;
}