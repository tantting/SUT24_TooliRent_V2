using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        /// Get all bookings
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadBookingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadBookingDto>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // Get bookings by ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadBookingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadBookingDto>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) return NotFound($"Booking with ID {id} not found");
            return Ok(booking);
        }

        // Get bookings by user ID
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<ReadBookingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadBookingDto>>> GetBookingsByUserId(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }

        
        //Create a new booking with one or many tools
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateBooking([FromBody] CreateBookingRequestDto dto, CancellationToken ct = default)
        {
            var result = await _bookingService.CreateBookingAsync(dto, ct);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return CreatedAtAction(
                nameof(GetBookingById),
                new { id = result.Data },
                result.Data
            );
        }
        
        //Delete booking
        // Delete a booking
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result.Success) return BadRequest(result.ErrorMessage);
            return NoContent();
        }
        
    }
}
