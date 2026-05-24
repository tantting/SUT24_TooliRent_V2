namespace SUT24_TooliRent_V2.AuthDtos;

public record RefreshDto
{
    public string RefreshToken { get; init; } = string.Empty;
}
