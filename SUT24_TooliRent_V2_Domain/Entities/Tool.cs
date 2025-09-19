using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Tool
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Namnet får max vara 100 tecken.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Beskrivningen får max vara 500 tecken.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsAvailable { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "WorkshopId måste vara större än 0.")]
    public int WorkshopId { get; set; }

    [Required] 
    public bool DemandsCertification { get; set; }

    public ToolCondition? Condition { get; set; }
    
    [Required]
    public ToolCategory Category { get; set; }
    
    // Navigation properties
    public Workshop Workshop { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}