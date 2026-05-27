using SUT24_TooliRent_V2_Application.DTOs.StatsDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Enums;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class StatsService : IStatsService
{
    private readonly IUnitOfWork _unitOfWork;

    public StatsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StatsDto> GetStatsAsync(CancellationToken ct = default)
    {
        var bookings = await _unitOfWork.Bookings.GetAllBookingsAsync(ct);
        var tools = await _unitOfWork.Tools.GetAllToolsAsync(ct);
        var members = await _unitOfWork.Members.GetAllAsync(ct);

        return new StatsDto
        {
            TotalBookings = bookings.Count,
            ReservedBookings = bookings.Count(b => b.Status == BookingStatus.Reserved),
            ActiveBookings = bookings.Count(b => b.Status == BookingStatus.Active),
            ReturnedBookings = bookings.Count(b => b.Status == BookingStatus.Returned),
            CancelledBookings = bookings.Count(b => b.Status == BookingStatus.Cancelled),
            OverdueBookings = bookings.Count(b => b.IsOverdue),

            TotalTools = tools.Count,
            AvailableTools = tools.Count(t => t.IsAvailable),
            UnavailableTools = tools.Count(t => !t.IsAvailable),

            TotalMembers = members.Count,
            ActiveMembers = members.Count(m => m.IsActive),
            InactiveMembers = members.Count(m => !m.IsActive)
        };
    }
}
