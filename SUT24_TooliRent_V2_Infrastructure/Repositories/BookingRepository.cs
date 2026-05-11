using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Booking>> GetAllBookingsAsync(CancellationToken ct = default)
    {
        return await _context.Bookings
            .Include(b => b.BookingTools)
                .ThenInclude(bt => bt.Tool)
                .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
                .ThenInclude(bt => bt.Tool)
                .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member)
            .ToListAsync(ct);
    }

    public async Task<Booking?> GetBookingByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Bookings
            .Include(b => b.BookingTools)
                .ThenInclude(bt => bt.Tool)
                .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
                .ThenInclude(bt => bt.Tool)
                .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member)
            .FirstOrDefaultAsync(b => b.Id == id, ct);
    }

    public Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default)
    {
        return _context.Bookings
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member)
            .Where(b => b.BookingTools.Any(bt => bt.ToolId == toolId))
            .ToListAsync(ct);
    }

    public Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default)
    {
        return _context.Bookings
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member)
            .Where(b => b.MemberId == userId)
            .ToListAsync(ct);
    }

    public void AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
    }

    public void UpdateBooking(Booking booking)
    {
        _context.Bookings.Update(booking);
    }

    public void DeleteBooking(Booking booking)
    {
        _context.Bookings.Remove(booking);
    }
}
