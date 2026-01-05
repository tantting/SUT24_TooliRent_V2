using Microsoft.AspNetCore.Identity;
using SUT24_TooliRent_V2_Domain.Entities;

namespace Infrastructure.Auth;

public class ApplicationUser : IdentityUser
{
    //Audit
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow; 
    
    //Navigation
    public Member Member { get; set; }
}