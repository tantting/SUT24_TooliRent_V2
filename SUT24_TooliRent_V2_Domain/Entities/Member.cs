using System.ComponentModel.DataAnnotations;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Member
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string personalNumber { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public DateTime MembershipDate { get; set; } = DateTime.UtcNow;

    [Required] public bool IsActive { get; set; } = default;
}