using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingToolController : ControllerBase
    {
        private readonly IBookingToolService _bookingToolService;

        public BookingToolController(IBookingToolService bookingToolService)
        {
            _bookingToolService = bookingToolService;
        }

        // Pick-up tool and change Returnstatus to Fetched (POST: api/bookings/123/tools/456/pickup)
        [HttpPost("{toolId}/pickup")]
        public async Task<IActionResult> PickupTool(int bookingId, int toolId)
        {
            var result = await _bookingToolService.MarkAsPickedUpAsync(bookingId, toolId);
            if (!result.Success) return BadRequest(result.ErrorMessage);
            return NoContent();
        }

        //Return tool and change Returnstatus to ReturnedOk (PUT: api/bookings/123/tools/456/return)
        [HttpPut("{toolId}/return")]
        public async Task<IActionResult> ReturnTool(int bookingId, int toolId, [FromBody] ReturnToolDto dto)
        {
            var result = await _bookingToolService.MarkAsReturnedAsync(bookingId, toolId, dto.ReturnStatus);
            if (!result.Success) return BadRequest(result.ErrorMessage);
            return NoContent();
        }




    }
}
