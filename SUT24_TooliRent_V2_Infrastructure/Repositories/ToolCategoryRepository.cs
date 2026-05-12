using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ToolCategoryRepository : IToolCategoryRepository
{
    private readonly AppDbContext _context;

    public ToolCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ToolCategory>> GetAllAsync(CancellationToken ct = default)
        => await _context.ToolCategories.ToListAsync(ct);

    public async Task<ToolCategory?> GetByIdAsync(int id, CancellationToken ct = default)
        => await _context.ToolCategories.FindAsync([id], ct);

    public void Add(ToolCategory category)
        => _context.ToolCategories.Add(category);

    public void Delete(ToolCategory category)
        => _context.ToolCategories.Remove(category);
}
