using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Certification
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int ToolId { get; set; }
    [Required]
    public int MemberId { get; set; } 
    [Required]
    public DateTime CertificationDate { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime ExpirationDate { get; set; }  = DateTime.UtcNow.AddYears(1);
    [Required]
    public CertificationType Type { get; set; }

    // Navigation properties
    public Tool Tool { get; set; }
    public Member Member { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}