using Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace Infrastructure.Data;

public static class AppSeed
{
    public static async Task SeedDomainDataAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // --- 1. Seed Workshops ---
        if (!await db.Workshops.AnyAsync())
        {
            var workshops = new List<Workshop>
            {
                new() { Name = "Träverkstad", Description = "För träarbete" },
                new() { Name = "Metallverkstad", Description = "För metallbearbetning" }
            };
            db.Workshops.AddRange(workshops);
            await db.SaveChangesAsync();
        }

        // --- 2. Seed ToolCategories ---
        if (!await db.ToolCategories.AnyAsync())
        {
            var categories = new List<ToolCategory>
            {
                new() { Name = "Handverktyg", Description = "Skruvmejslar, hammare, tänger" },
                new() { Name = "Elverktyg", Description = "Borrmaskiner, cirkelsågar" },
                new() { Name = "Maskiner", Description = "Tyngre utrustning som CNC, svets" }
            };
            db.ToolCategories.AddRange(categories);
            await db.SaveChangesAsync();
        }

        // --- 3. Seed Tools med alla ToolCondition ---
        if (!await db.Tools.AnyAsync())
        {
            var tools = new List<Tool>
            {
                new() { Name = "Hammare", Description="Standard hammare", IsAvailable=true, WorkshopId=1, ToolCategoryId=1, DemandsCertification=false, Condition=ToolCondition.New },
                new() { Name = "Skruvmejsel", Description="Skruvmejselset", IsAvailable=true, WorkshopId=1, ToolCategoryId=1, DemandsCertification=false, Condition=ToolCondition.Good },
                new() { Name = "Borrmaskin", Description="Elborrmaskin 500W", IsAvailable=true, WorkshopId=1, ToolCategoryId=2, DemandsCertification=true, Condition=ToolCondition.NeedsRepair },
                new() { Name = "Svets", Description="Industrisvets", IsAvailable=false, WorkshopId=2, ToolCategoryId=3, DemandsCertification=true, Condition=ToolCondition.Broken }
            };
            db.Tools.AddRange(tools);
            await db.SaveChangesAsync();
        }

        // --- 4. Seed Members och koppla till ApplicationUser ---
        if (!await db.Members.AnyAsync())
        {
            var members = new List<Member>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Anna",
                    LastName = "Andersson",
                    PersonalNumber = "19800101-1234",
                    PhoneNumber = "0701234567",
                    Address = "Storgatan 1",
                    MembershipValidUntil = DateTime.UtcNow.AddYears(1),
                    IsActive = true
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bertil",
                    LastName = "Bengtsson",
                    PersonalNumber = "19900202-5678",
                    PhoneNumber = "0709876543",
                    Address = "Lillgatan 2",
                    MembershipValidUntil = DateTime.UtcNow.AddYears(1),
                    IsActive = true
                }
            };

            foreach (var member in members)
            {
                // Skapa IdentityUser för medlem
                var email = $"{member.FirstName.ToLower()}@example.com";
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "Member123!");
                await userManager.AddToRoleAsync(user, "Member");

                member.IdentityUserId = user.Id;
            }

            db.Members.AddRange(members);
            await db.SaveChangesAsync();
        }

        // --- 5. Seed Bookings med alla BookingStatus och ReturnStatus ---
        if (!await db.Bookings.AnyAsync())
        {
            var members = await db.Members.ToListAsync();
            var bookings = new List<Booking>
            {
                new() { MemberId = members[0].Id, StartDate=DateTime.UtcNow, EndDate=DateTime.UtcNow.AddDays(7), Status=BookingStatus.Pending },
                new() { MemberId = members[0].Id, StartDate=DateTime.UtcNow.AddDays(-5), EndDate=DateTime.UtcNow.AddDays(2), Status=BookingStatus.Reserved },
                new() { MemberId = members[1].Id, StartDate=DateTime.UtcNow.AddDays(-10), EndDate=DateTime.UtcNow.AddDays(-2), Status=BookingStatus.Active },
                new() { MemberId = members[1].Id, StartDate=DateTime.UtcNow.AddDays(-20), EndDate=DateTime.UtcNow.AddDays(-10), Status=BookingStatus.Returned },
                new() { MemberId = members[1].Id, StartDate=DateTime.UtcNow, EndDate=DateTime.UtcNow.AddDays(3), Status=BookingStatus.Cancelled }
            };
            db.Bookings.AddRange(bookings);
            await db.SaveChangesAsync();

            // BookingTools med alla ReturnStatus
            var tools = await db.Tools.ToListAsync();
            var bookingTools = new List<BookingTool>();
            var returnStatuses = Enum.GetValues(typeof(ReturnStatus)).Cast<ReturnStatus>().ToList();

            int idx = 0;
            foreach (var booking in bookings)
            {
                bookingTools.Add(new BookingTool
                {
                    BookingId = booking.Id,
                    ToolId = tools[idx % tools.Count].Id,
                    ReturnStatus = returnStatuses[idx % returnStatuses.Count]
                });
                idx++;
            }

            db.BookingTools.AddRange(bookingTools);
            await db.SaveChangesAsync();
        }

        // --- 6. Seed Certifications med alla CertificationType ---
        if (!await db.Certifications.AnyAsync())
        {
            var members = await db.Members.ToListAsync();
            var tools = await db.Tools.ToListAsync();
            var certifications = new List<Certification>
            {
                // Standardcertifikat
                new() { MemberId = members[0].Id, Type=CertificationType.General, CertificationDate=DateTime.UtcNow, ExpirationDate=DateTime.UtcNow.AddYears(1) },
                new() { MemberId = members[0].Id, Type=CertificationType.PowerTools, CertificationDate=DateTime.UtcNow, ExpirationDate=DateTime.UtcNow.AddYears(1), ToolId = tools.First(t => t.DemandsCertification).Id },
                new() { MemberId = members[1].Id, Type=CertificationType.HeavyMachinery, CertificationDate=DateTime.UtcNow, ExpirationDate=DateTime.UtcNow.AddYears(1) },
                new() { MemberId = members[1].Id, Type=CertificationType.WorkshopSpecific, CertificationDate=DateTime.UtcNow, ExpirationDate=DateTime.UtcNow.AddYears(1), ToolId = tools.Last().Id }
            };
            db.Certifications.AddRange(certifications);
            await db.SaveChangesAsync();
        }
    }
}
