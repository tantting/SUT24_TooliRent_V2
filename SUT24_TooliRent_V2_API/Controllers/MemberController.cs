using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.MemberDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadMemberDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReadMemberDto>>> GetAllMembers(CancellationToken ct = default)
    {
        var members = await _memberService.GetAllMembersAsync(ct);
        return Ok(members);
    }

    [HttpPatch("{id}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SetMemberStatus(int id, [FromBody] SetMemberStatusDto dto, CancellationToken ct = default)
    {
        var result = await _memberService.SetMemberActiveStatusAsync(id, dto.IsActive, ct);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return NoContent();
    }
}
