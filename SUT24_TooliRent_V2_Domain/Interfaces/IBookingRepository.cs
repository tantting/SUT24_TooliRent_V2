using SUT24_TooliRent_V2_Domain.Entities;


namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IBookingRepository
{
    Task<List<Booking>> GetAllBookingsAsync(CancellationToken ct = default);
    Task<Booking?> GetBookingByIdAsync(int id, CancellationToken ct = default);
    Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default);
    Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default);
    void AddBookingAsync(Booking booking, CancellationToken ct = default);
    void  UpdateBookingAsync(Booking booking, CancellationToken ct = default);
    void DeleteBookingAsync(int id, CancellationToken ct = default);
    void BookingExistsAsync(int id, CancellationToken ct = default);
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
    
}