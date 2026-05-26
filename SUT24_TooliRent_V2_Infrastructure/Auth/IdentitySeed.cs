using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SUT24_TooliRent_V2_Application.DTOs.Member.DTOs;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace Infrastructure.Auth;

public static class IdentitySeed 
{
    
    public static async Task SeedRolesAndAdminAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // Create roles
        string[] roles = { "Admin", "Member" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Create admin
        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            await userManager.CreateAsync(adminUser, "Admin123!"); // Identity hashar automatiskt lösenordet
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    public static async Task SeedMembersAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var appDbContext = services.GetRequiredService<AppDbContext>();

        var users = new Dictionary<CreateMemberDto, string>
        {
            {
                new CreateMemberDto()
                {
                PersonalNumber = "8008124647",
                Name = "Anna Andersson",
                Email = "anna.andersson@mail.com",
                PhoneNumber = "0730567483",
                Address = "Verkstadsgatan 123, 12345",
                IsActive = true
                }, "Anna12345"
            },
            {
                new CreateMemberDto()
                {
                PersonalNumber = "8109134548",
                Name = "Bengt Bengtsson",
                Email = "bengtB@mail.com",
                PhoneNumber = "0732123456",
                Address = "Ångvägem 3, 43022 Överlida",
                IsActive = true
                }, "Bengt12345"
            }
        };
        
        foreach (var (dto, password) in users)
        {
                var newUser = await userManager.FindByEmailAsync(dto.Email);

                if (!appDbContext.Members.Any(m => m.Email == dto.Email) && newUser == null)
                {
                    newUser = new IdentityUser { UserName = dto.Email, Email = dto.Email, EmailConfirmed = true };
                    await userManager.CreateAsync(newUser, password); // Identity hashar automatiskt lösenordet
                    await userManager.AddToRoleAsync(newUser, "Member");

                    var newMember = new Member
                    {
                        PersonalNumber = dto.PersonalNumber,
                        Name = dto.Name,
                        Email = dto.Email,
                        PhoneNumber = dto.PhoneNumber,
                        Address = dto.Address,
                        IsActive = dto.IsActive,
                        IdentityUserId = newUser.Id
                    };
                    appDbContext.Members.Add(newMember);
                    await appDbContext.SaveChangesAsync();
                    
                    // save booking - SaveChanges sets booking.Id
                    var booking = new Booking
                    {
                        MemberId = newMember.Id,
                        StartDate = DateTime.UtcNow.AddDays(1),
                        EndDate = DateTime.UtcNow.AddDays(8),
                        Status = BookingStatus.Reserved
                    };
                    appDbContext.Bookings.Add(booking);
                    await appDbContext.SaveChangesAsync();

                    // BookingTool demands a booking.Id - is added after SaveChanges
                    var bookingTool = new BookingTool
                    {
                        BookingId = booking.Id,
                        ToolId = 1,
                        ReturnStatus = ReturnStatus.NotFetched
                    };
                    appDbContext.BookingTools.Add(bookingTool);

                    // Certifikat
                    var certification = new Certification
                    {
                        MemberId = newMember.Id,
                        Type = CertificationType.General,
                        CertificationDate = DateTime.UtcNow,
                        ExpirationDate = DateTime.UtcNow.AddYears(1)
                    };
                    appDbContext.Certifications.Add(certification);

                    await appDbContext.SaveChangesAsync();
                }
        }
    }
    
}