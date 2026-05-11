namespace SUT24_TooliRent_V2_Application.DTOs.BookingToolDTOs;

public record ReadBookingToolDto
{
    public int ToolId { get; init; }
    public string ToolName { get; init; }
    public string ToolCategory { get; init; }
    public bool ToolDemandsCertification { get; init; }
    
    public int Quantity { get; init; }
    public string ReturnStatus { get; init; }
}