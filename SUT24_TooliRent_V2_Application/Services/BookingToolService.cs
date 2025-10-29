using System.Xml.XPath;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class BookingToolService : IBookingToolService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingToolService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> MarkAsPickedUpAsync(int bookingId, int toolId, CancellationToken ct = default)
    {
        var bookingTool = await _unitOfWork.BookingTools.GetBookingToolAsync(bookingId, toolId);

        if (bookingTool == null)
        {
            return Result.Fail("BookingTool not found"); 
        }

        bookingTool.ReturnStatus = ReturnStatus.Fetched;
        
        // Change booking status if still as reserved
        var booking = bookingTool.Booking;
        if (booking.Status == BookingStatus.Reserved)
        {
            booking.Status = BookingStatus.Active;
        }
        
        await _unitOfWork.SaveChangesAsync(ct);

        return Result.Ok(); 
    }

    public async Task<Result> MarkAsReturnedAsync(int bookingId, int toolId, ReturnStatus returnStatus, CancellationToken ct = default)
    {
        var bookingTool = await _unitOfWork.BookingTools.GetBookingToolAsync(bookingId, toolId);
        if (bookingTool == null)
        {
            return Result.Fail("BookingTool not found"); 
        }
        bookingTool.ReturnStatus = returnStatus;

        var booking = bookingTool.Booking; 
        if (booking.BookingTools.All(bt => bt.ReturnStatus == ReturnStatus.ReturnedOk))
        {
            booking.Status = BookingStatus.Returned;
            await _unitOfWork.SaveChangesAsync(ct);
        }
        
        await _unitOfWork.SaveChangesAsync(ct);

        return Result.Ok(); 
    }
}