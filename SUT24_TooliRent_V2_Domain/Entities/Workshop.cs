using System.ComponentModel.DataAnnotations;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Workshop : AuditableEntity
{ 
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    // Navigation properties
    public ICollection<Tool> Tools { get; set; } = new List<Tool>();
}