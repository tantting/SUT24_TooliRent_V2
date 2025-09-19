using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IToolRepository
{
    Task<List<Tool>> GetAllToolsAsync();
    Task<Tool?> GetToolByIdAsync(int id);
    Task<List<Tool>> GetToolsByNameAsync(string name);
    Task<List<Tool>> GetToolsByCategoryAsync(string category);
}