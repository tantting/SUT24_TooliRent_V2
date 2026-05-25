using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.CategoryDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;

namespace SUT24_TooliRent_V2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ToolCategoryController : ControllerBase
{
    private readonly IToolCategoryService _categoryService;

    public ToolCategoryController(IToolCategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadToolCategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReadToolCategoryDto>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadToolCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadToolCategoryDto>> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category is null) return NotFound($"Category with ID {id} not found");
        return Ok(category);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(typeof(ReadToolCategoryDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReadToolCategoryDto>> CreateCategory([FromBody] CreateToolCategoryDto dto, CancellationToken ct = default)
    {
        var result = await _categoryService.CreateCategoryAsync(dto, ct);
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return CreatedAtAction(nameof(GetCategoryById), new { id = result.Data!.Id }, result.Data);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken ct = default)
    {
        var result = await _categoryService.DeleteCategoryAsync(id, ct);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return NoContent();
    }
}
