using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Certification : AuditableEntity
{
    [Key]
    public int Id { get; set; }
    public CertificationType Type { get; set; }
    
    // Many-to-many standardcertifikat
    public ICollection<Tool> Tools { get; set; } = new List<Tool>();

    // Optional: specialcertifikat kopplat till ett specifikt verktyg
    public int? ToolId { get; set; }
    public Tool? Tool { get; set; }
    
    public Guid MemberId { get; set; } 
    
    public Member Member { get; set; }
    
    public DateTime CertificationDate { get; set; } = DateTime.UtcNow;
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddYears(1);
}