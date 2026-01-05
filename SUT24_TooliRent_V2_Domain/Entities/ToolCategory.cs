using System.ComponentModel.DataAnnotations;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class ToolCategory : AuditableEntity
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; } = string.Empty;
    public ICollection<Tool> Tools { get; set; } = new List<Tool>();
    
}