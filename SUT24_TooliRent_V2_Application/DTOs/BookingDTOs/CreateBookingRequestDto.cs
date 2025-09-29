using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;

public record CreateBookingRequestDto
{
    public int MemberId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // List of toolId:s to be booked
    public List<int> ToolIds { get; set; } = new();
    
}