using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Tool
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100, ErrorMessage = "Namnet får max vara 100 tecken.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Beskrivningen får max vara 500 tecken.")]
    public string Description { get; set; } = string.Empty;
    
    public bool IsAvailable { get; set; }
    public int WorkshopId { get; set; }
    public bool DemandsCertification { get; set; }

    public ToolCondition Condition { get; set; }
    
    public int ToolCategoryId { get; set; }
    
    // Navigation properties
    public Workshop Workshop { get; set; }
    public ToolCategory ToolCategory { get; set; }
    public ICollection<BookingTool> BookingTools { get; set; } = new List<BookingTool>();
    
    // Nav for Standard certificat
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    //Nav for  Special certificat
    public ICollection<Certification> SpecialCertifications { get; set; } = new List<Certification>();

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}