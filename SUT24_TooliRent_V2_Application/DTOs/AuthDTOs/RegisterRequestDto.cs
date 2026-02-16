namespace SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;

public record RegisterRequestDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; }
}