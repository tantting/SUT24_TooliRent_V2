namespace SUT24_TooliRent_V2.AuthDtos;

public record RegisterDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}