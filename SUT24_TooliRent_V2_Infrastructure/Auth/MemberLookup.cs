using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Application.Interfaces;
using SUT24_TooliRent_V2_Domain.Entities;

namespace Infrastructure.Auth;

public class MemberLookup : IMemberLookup
{
    private readonly AppDbContext _db;

    public MemberLookup(AppDbContext db)
    {
        _db = db; 
    }
    
    public async Task<Member?> GetByIdentityUserIdAsync(string IdentityUserId, CancellationToken ct)
    {
        return await _db.Members.FirstOrDefaultAsync(m => m.IdentityUserId == IdentityUserId, ct); 
    }
}