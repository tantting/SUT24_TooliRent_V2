using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class Booking
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime StartDate { get; set; }  = DateTime.UtcNow;
    [Required]
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int ToolId { get; set; }
    [Required]
    public BookingStatus Status { get; set; }

    // Navigation properties
    public Member Member { get; set; }
    public Tool Tool { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}