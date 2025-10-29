using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
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

    public IQueryable<Booking> GetAllBookingsQuery()
    {
        return _context.Bookings
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member);
    }

public IQueryable<Booking> GetBookingByIdQuery(int id)
    {
        return _context.Bookings
            .Where(b => b.Id == id)
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.Workshop)
            .Include(b => b.BookingTools)
            .ThenInclude(bt => bt.Tool)
            .ThenInclude(t => t.ToolCategory)
            .Include(b => b.Member);
    }

    public Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void AddBooking(Booking booking, CancellationToken ct = default)
    {
        _context.Bookings.Add(booking);
    }

    public void UpdateBooking(Booking booking, CancellationToken ct = default)
    {
        _context.Bookings.Update(booking);
    }

    public void DeleteBooking(int id, CancellationToken ct = default)
    {
        _context.Bookings.Remove(new Booking { Id = id });
    }

    public void BookingExists(int id, CancellationToken ct = default)
    {
        _context.Bookings.Any(b => b.Id == id);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
    }
}
