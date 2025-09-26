using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

    public interface IToolService
    {
        Task<IEnumerable<ReadToolDto>> GetAllToolsAsync(CancellationToken ct = default);
        Task<ReadToolDto?> GetToolByIdAsync(int id, CancellationToken ct = default);
        // Task<IEnumerable<ReadToolDto>> GetToolsByNameAsync(string name, CancellationToken ct = default);
        Task<IEnumerable<ReadToolDto>> GetToolsByCategoryAsync(ToolCategory category, CancellationToken ct = default);  
        Task<IEnumerable<ReadToolDto>> GetToolsByConditionAsync(ToolCondition condition, CancellationToken ct = default);
        Task<IEnumerable<ReadToolDto>> GetAvailableToolsAsync(CancellationToken ct = default);
        Task <Result<ReadToolDto>>  CreateToolAsync(CreateToolDto dto, CancellationToken ct = default);
        Task<Result<ReadToolDto>> UpdateToolAsync(UpdateToolDto dto, CancellationToken ct = default);
        Task<Result> DeleteToolAsync(int id, CancellationToken ct = default);
        Task<bool> ToolExistsAsync(int id, CancellationToken ct = default);
    }