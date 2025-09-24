using Infrastructure.Data;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBookingRepository _bookings;
    private IToolRepository _tools;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }   
    
    public IBookingRepository Bookings => 
        _bookings ??= new BookingRepository(_context);
    
    public IToolRepository Tools => 
        _tools ??= new ToolRepository(_context);
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}