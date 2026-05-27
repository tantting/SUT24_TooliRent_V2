namespace SUT24_TooliRent_V2_Domain.Enums;

public enum BookingStatus
{
    /// <summary>
    /// Verktyget är reserverat för medlemmen under perioden.
    /// </summary>
    Reserved = 0,

    /// <summary>
    /// Verktyget är utlånat och bokningen är aktiv just nu.
    /// </summary>
    Active = 1,

    /// <summary>
    /// Verktyget är återlämnat och bokningen är avslutad.
    /// </summary>
    Returned = 2,

    /// <summary>
    /// Bokningen har avbrutits och verktyget är tillgängligt igen.
    /// </summary>
    Cancelled = 3
}