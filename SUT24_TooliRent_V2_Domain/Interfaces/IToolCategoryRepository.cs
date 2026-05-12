using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IToolCategoryRepository
{
    Task<List<ToolCategory>> GetAllAsync(CancellationToken ct = default);
    Task<ToolCategory?> GetByIdAsync(int id, CancellationToken ct = default);
    void Add(ToolCategory category);
    void Delete(ToolCategory category);
}
