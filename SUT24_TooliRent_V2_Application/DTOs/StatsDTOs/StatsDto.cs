namespace SUT24_TooliRent_V2_Application.DTOs.StatsDTOs;

public record StatsDto
{
    public int TotalBookings { get; init; }
    public int ReservedBookings { get; init; }
    public int ActiveBookings { get; init; }
    public int ReturnedBookings { get; init; }
    public int CancelledBookings { get; init; }
    public int OverdueBookings { get; init; }

    public int TotalTools { get; init; }
    public int AvailableTools { get; init; }
    public int UnavailableTools { get; init; }

    public int TotalMembers { get; init; }
    public int ActiveMembers { get; init; }
    public int InactiveMembers { get; init; }
}
