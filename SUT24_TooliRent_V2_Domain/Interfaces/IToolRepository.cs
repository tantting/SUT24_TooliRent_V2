using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IToolRepository
{
    Task<List<Tool>> GetAllToolsAsync(CancellationToken ct = default);
    Task<Tool?> GetToolByIdAsync(int id, CancellationToken ct = default);
    Task<List<Tool>> GetToolsByNameAsync(string name, CancellationToken ct = default);
    Task<List<Tool>> GetToolsByCategoryAsync(ToolCategory category, CancellationToken ct = default);  
    Task<List<Tool>> GetToolsByConditionAsync(ToolCondition condition, CancellationToken ct = default);
    Task<List<Tool>> GetAvailableToolsAsync(CancellationToken ct = default);
    void  AddToolAsync(Tool tool, CancellationToken ct = default);
    void UpdateToolAsync(Tool tool, CancellationToken ct = default);
    void DeleteToolAsync(int id, CancellationToken ct = default);
    void ToolExistsAsync(int id, CancellationToken ct = default);
    Task<bool> SaveChangesAsync(CancellationToken ct = default);
}