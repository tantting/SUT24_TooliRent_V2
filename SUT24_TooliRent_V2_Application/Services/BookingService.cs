using AutoMapper;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
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
        var bookings = await _unitOfWork.Bookings.GetAllBookingsAsync(ct);
        return _mapper.Map<IEnumerable<ReadBookingDto>>(bookings);
    }

    public async Task<ReadBookingDto?> GetBookingByIdAsync(int id, CancellationToken ct = default)
    {
        var booking = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        return booking is null ? null : _mapper.Map<ReadBookingDto>(booking);
    }

    public async Task<IEnumerable<ReadBookingDto>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default)
    {
        var bookings = await _unitOfWork.Bookings.GetBookingsByUserIdAsync(userId, ct);
        return _mapper.Map<IEnumerable<ReadBookingDto>>(bookings);
    }


    public async Task<Result<int>> CreateBookingAsync(CreateBookingRequestDto dto, CancellationToken ct = default)
    {
        try 
        {
            var booking = _mapper.Map<Booking>(dto);
            _unitOfWork.Bookings.AddBooking(booking);
            await _unitOfWork.SaveChangesAsync(ct);
        
            return Result<int>.Ok(booking.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }

    public async Task<Result<ReadBookingDto>> DeleteBookingAsync(int id, CancellationToken ct = default)
    {
        var booking = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);
        
        if (booking == null)
            return Result<ReadBookingDto>.Fail($"Booking with id {id} not found");
        
        var dto = _mapper.Map<ReadBookingDto>(booking);
        
        _unitOfWork.Bookings.DeleteBooking(booking);
        await _unitOfWork.SaveChangesAsync(ct);
        return Result<ReadBookingDto>.Ok(dto);
    }

    public async Task<Result<ReadBookingDto>> UpdateBookingAsync(int id, UpdateBookingRequestDto dto,
        CancellationToken ct = default)
    {
        var booking = await _unitOfWork.Bookings.GetBookingByIdAsync(id, ct);

        if (booking is null)
            return Result<ReadBookingDto>.Fail($"Booking with id {id} not found");

        _mapper.Map(dto, booking);
        _unitOfWork.Bookings.UpdateBooking(booking);
        await _unitOfWork.SaveChangesAsync(ct);

        return Result<ReadBookingDto>.Ok(_mapper.Map<ReadBookingDto>(booking));
    }
}