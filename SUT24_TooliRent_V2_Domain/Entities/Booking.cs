using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Booking
{
    [Key]
    public int Id { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);
    public int MemberId { get; set; }
    public int ToolId { get; set; }
    public BookingStatus Status { get; set; }

    // Navigation properties
    public Member Member { get; set; }
    public Tool Tool { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}