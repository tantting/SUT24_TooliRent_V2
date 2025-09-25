using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ToolRepository : IToolRepository
{
    private readonly AppDbContext _context;
    public ToolRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task <List<Tool>> GetAllToolsAsync(CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .ToListAsync();
    }

    public async Task<Tool?> GetToolByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .FirstOrDefaultAsync(t => t.Id == id, ct);
    }

    public  async Task<List<Tool>> GetToolsByNameAsync(string name, CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .Where(t => t.Name.Contains(name))
            .ToListAsync(ct);
    }

    public async Task<List<Tool>> GetToolsByCategoryAsync(ToolCategory category, CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .Where(t => t.Category == category)
            .ToListAsync(ct);   
    }

    public async Task<List<Tool>> GetToolsByConditionAsync(ToolCondition condition, CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .Where(t => t.Condition == condition)
            .ToListAsync(ct);
    }

    public async Task<List<Tool>> GetAvailableToolsAsync(CancellationToken ct = default)
    {
        return await _context.Tools
            .AsNoTracking()
            .Include(t => t.Workshop)
            .Where(t => t.IsAvailable)
            .ToListAsync(ct);
    }

    public void AddTool(Tool tool, CancellationToken ct = default)
    {
        _context.Tools.AddAsync(tool, ct);
    }

    public void UpdateTool(Tool tool, CancellationToken ct = default)
    {
       _context.Tools.Update(tool);
    }

    public void DeleteTool(int id, CancellationToken ct = default)
    {
        _context.Tools.Remove(new Tool { Id = id });
    }

    public void ToolExists(int id, CancellationToken ct = default)
    {
        _context.Tools.Any(t => t.Id == id);
    }

    public  async Task<bool> SaveChangesAsync(CancellationToken ct = default)
    {
       return await _context.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
    }
}