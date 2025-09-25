using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs;

public record CreateToolDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    public int WorkshopId { get; set; }

    [Required]
    public ToolCategory Category { get; set; }

    public bool IsAvailable { get; set; } = true;
    public bool DemandsCertification { get; set; }
    public ToolCondition Condition { get; set; } = ToolCondition.New;
}