using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent_V2_Domain.Entities;
using SUT24_TooliRent_V2_Domain.Enums;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Certification> Certifications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Tool -> Workshop (many-to-one)
        modelBuilder.Entity<Tool>()
            .HasOne(t => t.Workshop)
            .WithMany(w => w.Tools)
            .HasForeignKey(t => t.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        // Tool -> Bookings (one-to-many)
        modelBuilder.Entity<Tool>()
            .HasMany(t => t.Bookings)
            .WithOne(b => b.Tool)
            .HasForeignKey(b => b.ToolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Tool -> Certifications (many-to-many standard cert)
        modelBuilder.Entity<Tool>()
            .HasMany(t => t.Certifications)
            .WithMany(c => c.Tools);

        // Tool -> SpecialCertifications (one-to-many)
        modelBuilder.Entity<Certification>()
            .HasOne(c => c.Tool)
            .WithMany(t => t.SpecialCertifications)
            .HasForeignKey(c => c.ToolId);

        // Certification -> Member (one-to-many)
        modelBuilder.Entity<Certification>()
            .HasOne(c => c.Member)
            .WithMany(m => m.Certifications)
            .HasForeignKey(c => c.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        // Enum-konverteringar
        modelBuilder.Entity<Tool>()
            .Property(t => t.Category)
            .HasConversion<string>();

        modelBuilder.Entity<Tool>()
            .Property(t => t.Condition)
            .HasConversion<string>();

        modelBuilder.Entity<Certification>()
            .Property(c => c.Type)
            .HasConversion<string>();
        
        //Seed Data
        
        // Workshops
        modelBuilder.Entity<Workshop>().HasData(
            new Workshop { Id = 1, Name = "Snickeriverkstaden", Description = "För träarbeten", CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
            new Workshop { Id = 2, Name = "Metallverkstaden", Description = "För metallarbete och svetsning", CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

        // Members
        modelBuilder.Entity<Member>().HasData(
            new Member { Id = 1, PersonalNumber = "8501011234", Name = "Anna Andersson", Email = "anna@example.com", PhoneNumber = "0701234567", Address = "Storgatan 1", MembershipDate = DateTime.UtcNow.AddYears(-2), IsActive = true },
            new Member { Id = 2, PersonalNumber = "9202025678", Name = "Björn Berg", Email = "bjorn@example.com", PhoneNumber = "0709876543", Address = "Lillgatan 5", MembershipDate = DateTime.UtcNow.AddYears(-1), IsActive = true }
        );

        // Tools med Category
        modelBuilder.Entity<Tool>().HasData(
            new Tool { Id = 1, Name = "Borrmaskin", Description = "En kraftfull borrmaskin", IsAvailable = true, WorkshopId = 1, DemandsCertification = true, Condition = ToolCondition.Good, Category = ToolCategory.PowerTools, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
            new Tool { Id = 2, Name = "Svets", Description = "MIG-svets för metall", IsAvailable = true, WorkshopId = 2, DemandsCertification = true, Condition = ToolCondition.Good, Category = ToolCategory.HeavyMachinery, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
            new Tool { Id = 3, Name = "Hammare", Description = "En klassisk hammare", IsAvailable = true, WorkshopId = 1, DemandsCertification = false, Condition = ToolCondition.Good, Category = ToolCategory.HandTools, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
            new Tool { Id = 4, Name = "Laseravståndsmätare", Description = "För precis mätning", IsAvailable = true, WorkshopId = 1, DemandsCertification = false, Condition = ToolCondition.Good, Category = ToolCategory.MeasuringTools, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

        // Certifications
        modelBuilder.Entity<Certification>().HasData(
            new Certification 
            { 
                Id = 1, 
                ToolId = null, // standardcertifikat
                MemberId = 1, 
                CertificationDate = DateTime.UtcNow.AddYears(-1), 
                ExpirationDate = DateTime.UtcNow.AddYears(1), 
                Type = CertificationType.General, 
                CreatedDate = DateTime.UtcNow, 
                UpdatedDate = DateTime.UtcNow 
            }
        );
        modelBuilder.Entity<Certification>().HasData(
            new Certification 
            { 
                Id = 2, 
                ToolId = 1, // kopplat till ett specifikt verktyg
                MemberId = 1, 
                CertificationDate = DateTime.UtcNow.AddMonths(-6), 
                ExpirationDate = DateTime.UtcNow.AddMonths(6), 
                Type = CertificationType.PowerTools, 
                CreatedDate = DateTime.UtcNow, 
                UpdatedDate = DateTime.UtcNow 
            }
        );
        
        // Bookings
        modelBuilder.Entity<Booking>().HasData(
            new Booking { Id = 1, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(7), MemberId = 1, ToolId = 1, Status = BookingStatus.Reserved, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
            new Booking { Id = 2, StartDate = DateTime.UtcNow.AddDays(1), EndDate = DateTime.UtcNow.AddDays(3), MemberId = 2, ToolId = 2, Status = BookingStatus.Pending, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Tool
                        || e.Entity is Member
                        || e.Entity is Workshop
                        || e.Entity is Booking
                        || e.Entity is Certification);
        
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                entry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    }