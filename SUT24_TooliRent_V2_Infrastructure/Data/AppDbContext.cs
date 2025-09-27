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
    public DbSet<ToolCategory> ToolCategories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Tool -> Workshop (many-to-one)
        modelBuilder.Entity<Tool>()
            .HasOne(t => t.Workshop)
            .WithMany(w => w.Tools)
            .HasForeignKey(t => t.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // BookingTool -> Booking (many-to-one)
        modelBuilder.Entity<BookingTool>()
            .HasOne(bt => bt.Booking)
            .WithMany(b => b.BookingTools)
            .HasForeignKey(bt => bt.BookingId);
        
        // BookingTool -> Tool (many-to-one)
        modelBuilder.Entity<BookingTool>()
            .HasOne(bt => bt.Tool)
            .WithMany(t => t.BookingTools)
            .HasForeignKey(bt => bt.ToolId);
        
        // Composite key
        modelBuilder.Entity<BookingTool>()
            .HasKey(bt => new { bt.BookingId, bt.ToolId });

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

        // Category  -> Tool (one-to-many)
        modelBuilder.Entity<Tool>()
            .HasOne(t => t.ToolCategory)
            .WithMany(tc => tc.Tools)
            .HasForeignKey(t => t.ToolCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tool>()
            .Property(t => t.Condition)
            .HasConversion<string>();

        modelBuilder.Entity<Certification>()
            .Property(c => c.Type)
            .HasConversion<string>();
        
        //Seed Data
        
        // --- ToolCategory ---
        modelBuilder.Entity<ToolCategory>().HasData(
            new ToolCategory
            {
                Id = 1,
                Name = "Handverktyg",
                Description = "Skruvmejslar, hammare, tänger",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new ToolCategory
            {
                Id = 2,
                Name = "Elverktyg",
                Description = "Borrmaskiner, cirkelsågar",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new ToolCategory
            {
                Id = 3,
                Name = "Maskiner",
                Description = "Tyngre utrustning som CNC, svets",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- Workshop ---
        modelBuilder.Entity<Workshop>().HasData(
            new Workshop
            {
                Id = 1,
                Name = "Träverkstad",
                Description = "För träarbete",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Workshop
            {
                Id = 2,
                Name = "Metallverkstad",
                Description = "För metallbearbetning",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- Tool ---
        modelBuilder.Entity<Tool>().HasData(
            new Tool
            {
                Id = 1,
                Name = "Hammare",
                Description = "Standard hammare",
                IsAvailable = true,
                WorkshopId = 1,
                ToolCategoryId = 1,
                DemandsCertification = false,
                Condition = ToolCondition.Good,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Tool
            {
                Id = 2,
                Name = "Borrmaskin",
                Description = "Elborrmaskin 500W",
                IsAvailable = true,
                WorkshopId = 1,
                ToolCategoryId = 2,
                DemandsCertification = true,
                Condition = ToolCondition.Good,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Tool
            {
                Id = 3,
                Name = "Svets",
                Description = "Industrisvets",
                IsAvailable = false,
                WorkshopId = 2,
                ToolCategoryId = 3,
                DemandsCertification = true,
                Condition = ToolCondition.NeedsRepair,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- Member ---
        modelBuilder.Entity<Member>().HasData(
            new Member
            {
                Id = 1,
                Name = "Anna Andersson",
                PersonalNumber = "19800101-1234",
                Email = "anna@example.com",
                PhoneNumber = "0701234567",
                Address = "Storgatan 1",
                MembershipDate = DateTime.UtcNow,
                MembershipValidUntil = DateTime.UtcNow.AddYears(1),
                IsActive = true
            },
            new Member
            {
                Id = 2,
                Name = "Bertil Bengtsson",
                PersonalNumber = "19900202-5678",
                Email = "bertil@example.com",
                PhoneNumber = "0709876543",
                Address = "Lillgatan 2",
                MembershipDate = DateTime.UtcNow,
                MembershipValidUntil = DateTime.UtcNow.AddYears(1),
                IsActive = true
            }
        );

// --- Booking ---
        modelBuilder.Entity<Booking>().HasData(
            new Booking
            {
                Id = 1,
                MemberId = 1,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                Status = BookingStatus.Reserved,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- BookingTool ---
        modelBuilder.Entity<BookingTool>().HasData(
            new BookingTool
            {
                BookingId = 1,
                ToolId = 1,
                ReturnStatus = ReturnStatus.NotReturned,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new BookingTool
            {
                BookingId = 1,
                ToolId = 2,
                ReturnStatus = ReturnStatus.NotReturned,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- Standardcertifikat (gäller flera verktyg) ---
        modelBuilder.Entity<Certification>().HasData(
            new Certification
            {
                Id = 1,
                Type = CertificationType.General,
                MemberId = 1,
                CertificationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddYears(1),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            },
            new Certification
            {
                Id = 2,
                Type = CertificationType.PowerTools,
                MemberId = 2,
                CertificationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddYears(1),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
        );

// --- Specialcertifikat (kopplat till ett specifikt verktyg) ---
        modelBuilder.Entity<Certification>().HasData(
            new Certification
            {
                Id = 3,
                Type = CertificationType.WorkshopSpecific,
                ToolId = 2,
                MemberId = 1,
                CertificationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddYears(1),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }
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