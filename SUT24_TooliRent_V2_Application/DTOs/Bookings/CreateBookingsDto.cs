using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.Bookings;

public class CreateBookingsDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "MemberId måste vara större än 0.")]
    public int MemberId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ToolId måste vara större än 0.")]
    public int ToolId { get; set; }

    [Required]
    public BookingStatus Status { get; set; }
    
}