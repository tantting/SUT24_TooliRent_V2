using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Domain.Interfaces;

public interface IMemberRepository
{
    Task<List<Member>> GetAllAsync(CancellationToken ct = default);
    Task<Member?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Member?> GetByIdentityUserIdAsync(string identityUserId, CancellationToken ct = default);
}
