using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;

public class ReadBookingDto
{
    public int Id { get; set; }
    
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);
    public string MemberFirstName { get; set; }
    public string MemberLastName { get; set; }
    public string BookingStatus { get; set; }
    public bool IsOverdue { get; set; }
    public List<ReadBookingToolDto> Tools { get; set; } = new();
}