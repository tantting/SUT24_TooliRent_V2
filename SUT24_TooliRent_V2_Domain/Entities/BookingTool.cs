using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class BookingTool : AuditableEntity
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    public int ToolId { get; set; }
    public Tool Tool { get; set; }

    // Return status related to thus specific tool in the booking
    public ReturnStatus ReturnStatus { get; set; }
}

