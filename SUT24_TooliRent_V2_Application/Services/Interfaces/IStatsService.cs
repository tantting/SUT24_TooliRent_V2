using SUT24_TooliRent_V2_Application.DTOs.StatsDTOs;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IStatsService
{
    Task<StatsDto> GetStatsAsync(CancellationToken ct = default);
}
