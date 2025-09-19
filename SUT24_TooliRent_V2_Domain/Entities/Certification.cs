using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Certification
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ToolId måste vara större än 0.")]
    public int ToolId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "MemberId måste vara större än 0.")]
    public int MemberId { get; set; } 

    [Required]
    [DataType(DataType.Date)]
    public DateTime CertificationDate { get; set; } = DateTime.UtcNow;

    [Required]
    [DataType(DataType.Date)]
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddYears(1);

    [Required]
    public CertificationType Type { get; set; }

    // Navigation properties
    [Required]
    public Tool Tool { get; set; }
    [Required]
    public Member Member { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}