using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Application.Interfaces;

public interface IMemberLookup
{
    Task<Member?> GetByIdentityUserIdAsync(string IdentityUserId, CancellationToken ct); 
}