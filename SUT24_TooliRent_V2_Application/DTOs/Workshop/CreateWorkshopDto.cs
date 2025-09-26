using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Application.DTOs.Workshop;

public class CreateWorkshopDto
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage = "Namnet får max vara 100 tecken.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Beskrivningen får max vara 500 tecken.")]
    public string? Description { get; set; }

    // Navigation properties
    public ICollection<Tool> Tools { get; set; } = new List<Tool>();

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}