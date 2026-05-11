using SUT24_TooliRent_V2_Application.DTOs.BookingToolDTOs;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;

public record UpdateBookingRequestDto
{
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public BookingStatus? Status { get; init; }
}