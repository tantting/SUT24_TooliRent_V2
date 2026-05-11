using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
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

    public async Task<ReadToolDto?> GetToolByIdAsync(int id, CancellationToken ct = default)
    {
        var tool = await  _unitOfWork.Tools.GetToolByIdAsync(id, ct);
        return tool != null ? _mapper.Map<ReadToolDto>(tool) : null;
    }

    public async Task<IEnumerable<ReadToolDto>> GetToolsByCategoryAsync(int categoryId, CancellationToken ct = default)
    {
        var tools = await _unitOfWork.Tools.GetToolsByCategoryAsync(categoryId, ct);

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

    public async Task<Result<ReadToolDto>> CreateToolAsync(CreateToolDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<ReadToolDto>.Fail("Tool name is required");
        
        var newTool = _mapper.Map<Tool>(dto);
        _unitOfWork.Tools.AddTool(newTool);
        await _unitOfWork.SaveChangesAsync(ct);
        
        return Result<ReadToolDto>.Ok(_mapper.Map<ReadToolDto>(newTool));
    }

    public async Task<Result<ReadToolDto>> UpdateToolAsync(int id, UpdateToolDto dto, CancellationToken ct = default)
    {
        var tool = await _unitOfWork.Tools.GetToolByIdAsync(id, ct);
        if (tool is null)
            return Result<ReadToolDto>.Fail($"Tool with id {id} not found.");

        _mapper.Map(dto, tool);
        _unitOfWork.Tools.UpdateTool(tool);
        await _unitOfWork.SaveChangesAsync(ct);

        return Result<ReadToolDto>.Ok(_mapper.Map<ReadToolDto>(tool));
    }

    public async Task<Result> DeleteToolAsync(int id, CancellationToken ct = default)
    {
        var tool = await _unitOfWork.Tools.GetToolByIdAsync(id, ct);
        
        if (tool == null)
            return Result.Fail($"Tool with id {id} not found");
        
        _unitOfWork.Tools.DeleteTool(tool);
        await _unitOfWork.SaveChangesAsync(ct);
        
        return Result.Ok();
    }
}

