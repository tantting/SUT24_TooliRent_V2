using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IBookingToolRepository
{
    Task<BookingTool?> GetBookingToolAsync(int toolId, int bookingId, CancellationToken ct = default);
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
}