using SUT24_TooliRent_V2_Domain.Entities;


namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IBookingRepository
{
    Task<List<Booking>> GetAllBookingsAsync(CancellationToken ct = default);
    Task<Booking?> GetBookingByIdAsync(int id, CancellationToken ct = default);
    Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default);
    Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default);
    void AddBooking(Booking booking);
    void  UpdateBooking(Booking booking);
    void DeleteBooking(Booking booking);
    
}