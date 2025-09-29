using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ReadBookingDto>> GetAllBookingsAsync(CancellationToken ct = default)
    {
        var bookings = await _unitOfWork.Bookings.GetAllBookingsQuery()
            .ProjectTo<ReadBookingDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return bookings;
    }
    
    public async Task<ReadBookingDto?> GetBookingByIdAsync(int id, CancellationToken ct = default)
    {
        var booking = await _unitOfWork.Bookings.GetBookingByIdQuery(id)
            .ProjectTo<ReadBookingDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(ct);

        return booking;
    }

    public Task<IEnumerable<ReadBookingDto>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default)
    {
        var bookings = _unitOfWork.Bookings.GetAllBookingsQuery()
            .Where(b => b.MemberId == userId)
            .ProjectTo<ReadBookingDto>(_mapper.ConfigurationProvider)
            .AsEnumerable();

        return Task.FromResult(bookings);
    }


    public async Task<Result<int>> CreateBookingAsync(CreateBookingRequestDto dto, CancellationToken ct = default)
    {
        try 
        {
            var booking = _mapper.Map<Booking>(dto);
            _unitOfWork.Bookings.AddBooking(booking, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        
            return Result<int>.Ok(booking.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }

    public Task<Result<ReadBookingDto>> DeleteBookingAsync(int id, CancellationToken ct = default)
    {
        try
        {
            _unitOfWork.Bookings.DeleteBooking(id, ct);
            _unitOfWork.SaveChangesAsync(ct).Wait(ct);
            return Task.FromResult(Result<ReadBookingDto>.Ok(null!));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result<ReadBookingDto>.Fail(ex.Message));
        }
    }
}