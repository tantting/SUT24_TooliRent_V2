namespace SUT24_TooliRent_V2_Application.DTOs.MemberDTOs;

public record ReadMemberDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public bool IsActive { get; init; }
    public DateTime MembershipDate { get; init; }
    public DateTime MembershipValidUntil { get; init; }
}
