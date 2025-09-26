namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IUnitOfWork
{
    IBookingRepository Bookings { get; }
    IToolRepository Tools { get; }
   Task <int> SaveChangesAsync(CancellationToken ct);   
   
   
}