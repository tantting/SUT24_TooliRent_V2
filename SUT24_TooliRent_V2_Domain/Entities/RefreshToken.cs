using System.Runtime.InteropServices.JavaScript;

namespace SUT24_TooliRent_V2_Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Token { get; set; } = Guid.NewGuid().ToString("N");

    public Guid MemberId { get; set; }

    public DateTime ExpiresAtUtc { get; set;}
    public DateTime CreatedAtUtc { get; set; }
    public bool IsRevoked { get; set; }
}