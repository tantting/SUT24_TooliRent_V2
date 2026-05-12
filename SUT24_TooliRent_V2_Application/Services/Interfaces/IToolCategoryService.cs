using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.CategoryDTOs;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IToolCategoryService
{
    Task<IEnumerable<ReadToolCategoryDto>> GetAllCategoriesAsync(CancellationToken ct = default);
    Task<ReadToolCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken ct = default);
    Task<Result<ReadToolCategoryDto>> CreateCategoryAsync(CreateToolCategoryDto dto, CancellationToken ct = default);
    Task<Result> DeleteCategoryAsync(int id, CancellationToken ct = default);
}
