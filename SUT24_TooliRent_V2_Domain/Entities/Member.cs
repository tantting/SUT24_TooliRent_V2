using System.ComponentModel.DataAnnotations;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Member
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Personnummer måste vara exakt 10 siffror.")]
    public string PersonalNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Namn måste vara mellan 2 och 100 tecken.")]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(200, ErrorMessage = "Adress får max vara 200 tecken.")]
    public string Address { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime MembershipDate { get; set; } = DateTime.UtcNow;

    [Required] 
    public bool IsActive { get; set; } = default;
}