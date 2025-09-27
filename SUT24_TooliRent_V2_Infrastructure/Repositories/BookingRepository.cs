using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Application.DTOs.Bookings;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BookingRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<Booking> GetAllBookingsQuery(CancellationToken ct = default)
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

public Task<Booking?> GetBookingByIdAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void AddBookingAsync(Booking booking, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void UpdateBookingAsync(Booking booking, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void DeleteBookingAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void BookingExistsAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
