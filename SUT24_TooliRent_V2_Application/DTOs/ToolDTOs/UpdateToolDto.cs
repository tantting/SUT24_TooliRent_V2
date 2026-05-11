using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;

public record UpdateToolDto
{
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? WorkshopId { get; set; }
    public bool? IsAvailable { get; set; } = true;
    public bool? DemandsCertification { get; set; }
    public ToolCondition? Condition { get; set; }
    public int? ToolCategoryId { get; set; }
}