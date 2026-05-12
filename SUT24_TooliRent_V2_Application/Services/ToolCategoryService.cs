using AutoMapper;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.CategoryDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class ToolCategoryService : IToolCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ToolCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadToolCategoryDto>> GetAllCategoriesAsync(CancellationToken ct = default)
    {
        var categories = await _unitOfWork.Categories.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<ReadToolCategoryDto>>(categories);
    }

    public async Task<ReadToolCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken ct = default)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id, ct);
        return category is null ? null : _mapper.Map<ReadToolCategoryDto>(category);
    }

    public async Task<Result<ReadToolCategoryDto>> CreateCategoryAsync(CreateToolCategoryDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<ReadToolCategoryDto>.Fail("Category name is required");

        var category = _mapper.Map<ToolCategory>(dto);
        _unitOfWork.Categories.Add(category);
        await _unitOfWork.SaveChangesAsync(ct);
        return Result<ReadToolCategoryDto>.Ok(_mapper.Map<ReadToolCategoryDto>(category));
    }

    public async Task<Result> DeleteCategoryAsync(int id, CancellationToken ct = default)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id, ct);
        if (category is null)
            return Result.Fail($"Category with ID {id} not found");

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.SaveChangesAsync(ct);
        return Result.Ok();
    }
}
