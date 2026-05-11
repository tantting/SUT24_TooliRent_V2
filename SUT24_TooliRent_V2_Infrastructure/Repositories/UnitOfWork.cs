using AutoMapper;
using Infrastructure.Data;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBookingRepository _bookings;
    private IToolRepository _tools;
    private IBookingToolRepository _bookingTools;
    
    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        _context = context;
    }
    
    public IBookingRepository Bookings => 
        _bookings ??= new BookingRepository(_context);
    
    public IToolRepository Tools => 
        _tools ??= new ToolRepository(_context);

    public IBookingToolRepository BookingTools =>
        _bookingTools ??= new BookingToolRepository(_context); 

    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
}