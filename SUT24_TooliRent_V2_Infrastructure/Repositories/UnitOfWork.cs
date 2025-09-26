using AutoMapper;
using Infrastructure.Data;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBookingRepository _bookings;
    private IToolRepository _tools;
    private IMapper _mapper;
    
    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public IBookingRepository Bookings => 
        _bookings ??= new BookingRepository(_context, _mapper);
    
    public IToolRepository Tools => 
        _tools ??= new ToolRepository(_context);
    
    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
}