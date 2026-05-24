using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.StatsDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class StatsController : ControllerBase
{
    private readonly IStatsService _statsService;

    public StatsController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(StatsDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<StatsDto>> GetStats(CancellationToken ct = default)
    {
        var stats = await _statsService.GetStatsAsync(ct);
        return Ok(stats);
    }
}
