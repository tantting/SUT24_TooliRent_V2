using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.Bookings;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers;

public class BookingsController
{
    private readonly IBookingService _bookingService;
    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    //Get all bookings
    // [HttpGet]
    // [ProducesResponseType(typeof(IEnumerable<ReadBookingDto>), StatusCodes.Status200OK)]
    // public async Task<ActionResult<IEnumerable<ReadBookingDto>>> GetBookings()
    // {                              
    //     var bookings = await _bookingService.GetAllBookingsAsync();
    //     return Ok(bookings);
    // }
}