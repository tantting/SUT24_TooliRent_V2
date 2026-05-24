namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IUnitOfWork
{
    IBookingRepository Bookings { get; }
    IToolRepository Tools { get; }
    IBookingToolRepository BookingTools { get; }
    IToolCategoryRepository Categories { get; }
    IMemberRepository Members { get; }
    Task <int> SaveChangesAsync(CancellationToken ct);
}