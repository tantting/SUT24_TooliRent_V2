using SUT24_TooliRent_V2_Domain.Entities;


namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IBookingRepository
{
    IQueryable<Booking> GetAllBookingsQuery();
    IQueryable<Booking> GetBookingByIdQuery(int id);
    Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default);
    Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default);
    void AddBooking(Booking booking, CancellationToken ct = default);
    void  UpdateBooking(Booking booking, CancellationToken ct = default);
    void DeleteBooking(int id, CancellationToken ct = default);
    void BookingExists(int id, CancellationToken ct = default);
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
    
}