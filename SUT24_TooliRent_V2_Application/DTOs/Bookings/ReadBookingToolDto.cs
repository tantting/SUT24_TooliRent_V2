namespace SUT24_TooliRent_V2_Application.DTOs.Bookings;

public record ReadBookingToolDto
{
    public string ToolName { get; set; }
    public string ToolCategory { get; set; }
    public bool ToolDemandsCertification { get; set; }
    public int Quantity { get; set; }
    public string ReturnStatus { get; set; }
}