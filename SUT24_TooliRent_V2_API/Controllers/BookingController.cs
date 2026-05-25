using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMemberService _memberService;

        public BookingController(IBookingService bookingService, IMemberService memberService)
        {
            _bookingService = bookingService;
            _memberService = memberService;
        }
        
        /// Get all bookings
       
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<ReadBookingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadBookingDto>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // Get bookings by ID
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ReadBookingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadBookingDto>> GetBookingById(int id)
        {
            var bookings = await _bookingService.GetBookingByIdAsync(id);
            if (bookings == null) return NotFound($"Booking with ID {id} not found");
            return Ok(bookings);
        }

        // Get bookings by user ID
        [HttpGet("my")]
        [ProducesResponseType(typeof(IEnumerable<ReadBookingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadBookingDto>>> GetBookingsByUserId(CancellationToken ct)
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (identityUserId == null) return Unauthorized();

            var memberId = await _memberService.GetMemberIdByIdentityUserIdAsync(identityUserId, ct);
            if (memberId == null) return Unauthorized("No member profile found for this account.");
            
            var bookings = await _bookingService.GetBookingsByUserIdAsync(memberId.Value, ct);
            return Ok(bookings);
        }
        
        //Create a new booking with one or many tools
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> CreateBooking([FromBody] CreateBookingRequestDto dto, CancellationToken ct = default)
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (identityUserId == null) return Unauthorized();

            var memberId = await _memberService.GetMemberIdByIdentityUserIdAsync(identityUserId, ct);
            if (memberId == null) return Unauthorized("No member profile found for this account.");

            var result = await _bookingService.CreateBookingAsync(memberId.Value, dto, ct);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return CreatedAtAction(
                nameof(GetBookingById),
                new { id = result.Data },
                result.Data
            );
        }
        
        //Update a booking
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]            
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingRequestDto dto, CancellationToken ct = default)
        {
            var result = await _bookingService.UpdateBookingAsync(id, dto, ct);
            if (!result.Success) return BadRequest(result.ErrorMessage);
            return NoContent();
        }
        
        // Delete a booking — Admin kan alltid ta bort, member kan bara ta bort sin egen ej påbörjade bokning
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBooking(int id, CancellationToken ct)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) return NotFound($"Booking with ID {id} not found.");

            if (!User.IsInRole("Admin"))
            {
                if (booking.StartDate < DateTime.UtcNow)
                    return BadRequest("Cannot delete a booking that has already started. Contact admin for help.");

                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (identityUserId == null) return Unauthorized();

                var memberId = await _memberService.GetMemberIdByIdentityUserIdAsync(identityUserId, ct);
                if (memberId == null) return Unauthorized("No member profile found for this account.");
                if (booking.MemberId != memberId.Value) return Forbid();
            }

            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result.Success) return BadRequest(result.ErrorMessage);
            return NoContent();
        }
        
    }
}
