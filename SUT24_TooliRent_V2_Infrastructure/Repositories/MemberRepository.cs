using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAllAsync(CancellationToken ct = default)
        => await _context.Members.ToListAsync(ct);

    public async Task<Member?> GetByIdAsync(int id, CancellationToken ct = default)
        => await _context.Members.FindAsync([id], ct);
}
