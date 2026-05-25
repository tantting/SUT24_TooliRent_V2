using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.MemberDTOs;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IMemberService
{
    Task<IEnumerable<ReadMemberDto>> GetAllMembersAsync(CancellationToken ct = default);
    Task<Result> SetMemberActiveStatusAsync(int id, bool isActive, CancellationToken ct = default);
    Task<int?> GetMemberIdByIdentityUserIdAsync(string identityUserId, CancellationToken ct = default);
}
