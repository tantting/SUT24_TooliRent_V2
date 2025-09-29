using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;

public record ReadToolDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsAvailable { get; init; }
    public string ToolCategoryName { get; init; }
    public string ToolCondition { get; init; }
    public string Workshop { get; init; }
    public bool DemandsCertification { get; init; }
    
}