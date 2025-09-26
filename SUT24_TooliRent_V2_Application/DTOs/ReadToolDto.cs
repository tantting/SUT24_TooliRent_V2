using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs;

public record ReadToolDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal RentalPricePerDay { get; init; }
    public bool IsAvailable { get; init; }
    public ToolCategory Category { get; init; }
    public string CategoryName  => Category.ToString();
    public ToolCondition Condition { get; init; }  
    public string ConditionName  => Condition.ToString();
    public int WorkshopId { get; init; }
    public bool DemandsCertification { get; init; }
    
}