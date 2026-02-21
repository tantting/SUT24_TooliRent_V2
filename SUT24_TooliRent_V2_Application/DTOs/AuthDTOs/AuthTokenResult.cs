namespace SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;

public record AuthTokenResult(
    string AccessToken,
    DateTime ExpiresAtUtc
    );