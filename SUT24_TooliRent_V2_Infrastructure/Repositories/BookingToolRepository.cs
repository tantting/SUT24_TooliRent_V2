using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class BookingToolRepository : IBookingToolRepository
{
    private readonly AppDbContext _context;

    public BookingToolRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<BookingTool?> GetBookingToolAsync(int bookingId, int toolId,  CancellationToken ct = default)
    {
        return await _context.BookingTools
            .Include(bt => bt.Booking)           
            .ThenInclude(b => b.BookingTools)   
            .FirstOrDefaultAsync(bt => bt.BookingId == bookingId && bt.ToolId == toolId, ct);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
    }
}