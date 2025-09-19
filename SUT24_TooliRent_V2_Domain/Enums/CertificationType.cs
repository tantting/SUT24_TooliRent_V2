namespace SUT24_TooliRent_V2_Domain.Enums;

public enum CertificationType
{
    /// <summary>
    /// Grundnivå som alla medlemmar får när de blir aktiva.
    /// </summary>
    General = 0,

    /// <summary>
    /// För verktyg som riskerar skada, t.ex. cirkelsågar och borrmaskiner.
    /// </summary>
    PowerTools = 1,

    /// <summary>
    /// För farliga maskiner, t.ex. CNC, svetsar och industrimaskiner.
    /// </summary>
    HeavyMachinery = 2,

    /// <summary>
    /// Certifikat som är unikt för en viss verkstad.
    /// </summary>
    WorkshopSpecific = 3
}