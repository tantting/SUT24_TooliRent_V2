using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.Bookings;

public class ReadBookingDto
{
    public int Id { get; set; }
    
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);
    public string MemberName { get; set; }
    public string BookingStatus { get; set; }
    public List<ReadBookingToolDto> Tools { get; set; } = new();
}