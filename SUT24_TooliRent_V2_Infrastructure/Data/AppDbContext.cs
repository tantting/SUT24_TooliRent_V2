using Infrastructure.Auth;
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
        
       // ----------------------------
        // ApplicationUser <-> Member
        // ----------------------------
        modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.Member)
            .WithOne()
            .HasForeignKey<Member>(m => m.IdentityUserId)
            .IsRequired();

        // ----------------------------
        // Tool -> Workshop (many-to-one)
        // ----------------------------
        modelBuilder.Entity<Tool>()
            .HasOne(t => t.Workshop)
            .WithMany(w => w.Tools)
            .HasForeignKey(t => t.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // Booking -> Member (many-to-one)
        // ----------------------------
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Member)
            .WithMany(m => m.Bookings)
            .HasForeignKey(b => b.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // BookingTool -> Booking (many-to-one)
        // ----------------------------
        modelBuilder.Entity<BookingTool>()
            .HasOne(bt => bt.Booking)
            .WithMany(b => b.BookingTools)
            .HasForeignKey(bt => bt.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        // BookingTool -> Tool (many-to-one)
        modelBuilder.Entity<BookingTool>()
            .HasOne(bt => bt.Tool)
            .WithMany(t => t.BookingTools)
            .HasForeignKey(bt => bt.ToolId)
            .OnDelete(DeleteBehavior.Restrict);

        // Composite key
        modelBuilder.Entity<BookingTool>()
            .HasKey(bt => new { bt.BookingId, bt.ToolId });

        // ----------------------------
        // Tool -> Certifications (many-to-many standard cert)
        // ----------------------------
        modelBuilder.Entity<Tool>()
            .HasMany(t => t.Certifications)
            .WithMany(c => c.Tools);

        // Tool -> SpecialCertifications (one-to-many)
        modelBuilder.Entity<Certification>()
            .HasOne(c => c.Tool)
            .WithMany(t => t.SpecialCertifications)
            .HasForeignKey(c => c.ToolId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // Certification -> Member (one-to-many)
        modelBuilder.Entity<Certification>()
            .HasOne(c => c.Member)
            .WithMany(m => m.Certifications)
            .HasForeignKey(c => c.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // Tool -> ToolCategory (one-to-many)
        // ----------------------------
        modelBuilder.Entity<Tool>()
            .HasOne(t => t.ToolCategory)
            .WithMany(tc => tc.Tools)
            .HasForeignKey(t => t.ToolCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // ----------------------------
        // Enum konverteringar
        // ----------------------------
        modelBuilder.Entity<Tool>()
            .Property(t => t.Condition)
            .HasConversion<string>();

        modelBuilder.Entity<Certification>()
            .Property(c => c.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Booking>()
            .Property(b => b.Status)
            .HasConversion<string>();

        modelBuilder.Entity<BookingTool>()
            .Property(bt => bt.ReturnStatus)
            .HasConversion<string>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        
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