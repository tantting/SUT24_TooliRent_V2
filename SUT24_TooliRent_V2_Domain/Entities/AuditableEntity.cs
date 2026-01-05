namespace SUT24_TooliRent_V2_Domain.Entities;

public class AuditableEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}