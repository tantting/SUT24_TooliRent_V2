namespace SUT24_TooliRent_V2_Domain.Enums;

public enum BookingStatus
{
    // <summary>
    /// Bokningen är skapad men ännu inte bekräftad.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// Verktyget är reserverat för medlemmen under perioden.
    /// </summary>
    Reserved = 1,

    /// <summary>
    /// Verktyget är utlånat och bokningen är aktiv just nu.
    /// </summary>
    Active = 2,

    /// <summary>
    /// Verktyget är återlämnat och bokningen är avslutad.
    /// </summary>
    Returned = 3,

    /// <summary>
    /// Bokningen har avbrutits och verktyget är tillgängligt igen.
    /// </summary>
    Cancelled = 4
}