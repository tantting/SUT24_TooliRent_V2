using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IToolService _toolService;
        
        public ToolsController(AppDbContext context, IToolService toolService)
        {
            _context = context;
            _toolService = toolService;
        }
        
        // Get all tools
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadToolDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadToolDto>>> GetTools()
        {
            var tools = await _toolService.GetAllToolsAsync();
            return Ok(tools);
        }
        
        //Get all tools in specific Category
        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(typeof(IEnumerable<ReadToolDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadToolDto>>> GetToolsByCategory(int categoryId)
        {
            var tools = await _toolService.GetToolsByCategoryAsync(categoryId);
            return Ok(tools);
        }

        //Get all tools in specific Condition
        [HttpGet("condition/{condition}")]
        [ProducesResponseType(typeof(IEnumerable<ReadToolDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadToolDto>>> GetToolsByCondition(string condition)
        {
            var tools = await _toolService.GetToolsByConditionAsync((SUT24_TooliRent_V2_Domain.Enums
                .ToolCondition)Enum.Parse(typeof(SUT24_TooliRent_V2_Domain.Enums.ToolCondition), condition, true));
            return Ok(tools);
        }
        
        //Get all tools that are available
        [HttpGet("available")]
        [ProducesResponseType(typeof(IEnumerable<ReadToolDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadToolDto>>> GetAvailableTools()
        {
            var tools = await _toolService.GetAvailableToolsAsync();
            return Ok(tools);
        }   
        
        //Get tool by ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadToolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadToolDto>> GetToolById(int id)
        {
            var tool = await _toolService.GetToolByIdAsync(id);
            if (tool == null)
            {
                return NotFound($"Tool with ID {id} not found");
            }
            return Ok(tool);
        }
        
        //Create a new tool
        [HttpPost]
        [ProducesResponseType(typeof(ReadToolDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadToolDto>> CreateTool([FromBody] CreateToolDto dto)
        {
            var createdTool = await _toolService.CreateToolAsync(dto);
            return CreatedAtAction(nameof(GetToolById), new { id = createdTool.Data!.Id }, createdTool.Data);
        }
    }
}
