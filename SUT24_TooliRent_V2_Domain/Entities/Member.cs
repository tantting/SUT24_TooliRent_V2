using System.ComponentModel.DataAnnotations;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Member : AuditableEntity
{
    [Key]
    public Guid Id { get; set; }

    public string IdentityUserId { get; set; }
    public string PersonalNumber { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime MembershipValidUntil { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = default;
    
    // Navigation properties
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>(); 
}