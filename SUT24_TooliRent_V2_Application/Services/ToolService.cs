using AutoMapper;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class ToolService : IToolService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ToolService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReadToolDto>> GetAllToolsAsync(CancellationToken ct = default)
    {
        var tools = await  _unitOfWork.Tools.GetAllToolsAsync(ct);

        return _mapper.Map<IEnumerable<ReadToolDto>>(tools);
    }

    public Task<ReadToolDto?> GetToolByIdAsync(int id, CancellationToken ct = default)
    {
        
    }

    // public Task<IEnumerable<ReadToolDto>> GetToolsByNameAsync(string name, CancellationToken ct = default)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<IEnumerable<ReadToolDto>> GetToolsByCategoryAsync(ToolCategory category, CancellationToken ct = default)
    {
        var tools = await _unitOfWork.Tools.GetToolsByCategoryAsync(category, ct);

        return _mapper.Map<IEnumerable<ReadToolDto>>(tools); 
    }

    public async Task<IEnumerable<ReadToolDto>> GetToolsByConditionAsync(ToolCondition condition, CancellationToken ct = default)
    {
        var tools = await _unitOfWork.Tools.GetToolsByConditionAsync(condition, ct); 
        
        return _mapper.Map<IEnumerable<ReadToolDto>>(tools);
    }

    public async Task<IEnumerable<ReadToolDto>> GetAvailableToolsAsync(CancellationToken ct = default)
    {
        var tools = await _unitOfWork.Tools.GetAvailableToolsAsync(ct);
        
        return _mapper.Map<IEnumerable<ReadToolDto>>(tools);
    }

    public async Task<ReadToolDto> CreateToolAsync(CreateToolDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<ReadToolDto>.Fail("Tool name is required");
        
        var newTool = _mapper.Map<Tool>(dto);
        _unitOfWork.Tools.AddTool(newTool, ct);
        await _unitOfWork.SaveChangesAsync(ct);
        
        return _mapper.Map<ReadToolDto>(newTool);
    }

    public Task<Result<ReadToolDto>> UpdateToolAsync(UpdateToolDto dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteToolAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ToolExistsAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
    
    
    // private IEnumerable<ReadToolDto> MapToReadToolDtos(IEnumerable<Tool> tools)
    // {
    //     return tools.Select(tool => new ReadToolDto
    //     {
    //         Id = tool.Id,
    //         Name = tool.Name,
    //         Description = tool.Description,
    //         Category = tool.Category,
    //         Condition = tool.Condition,
    //         IsAvailable = tool.IsAvailable,
    //     });
    // }
}

