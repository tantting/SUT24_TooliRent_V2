using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class BookingTool
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    public int ToolId { get; set; }
    public Tool Tool { get; set; }

    // Return status related to thus specific tool in the booking
    public ReturnStatus ReturnStatus { get; set; }
    
    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}

