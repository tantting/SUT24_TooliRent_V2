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
    public DbSet<BookingTool> BookingTools { get; set; }

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


    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Tool
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