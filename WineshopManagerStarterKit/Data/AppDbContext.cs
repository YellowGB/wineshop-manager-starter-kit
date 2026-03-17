using Microsoft.EntityFrameworkCore;
using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<WineType> WineTypes { get; set; }
    public DbSet<Wine> Wines { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Unique index on Client.Email for fast lookups
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Email)
            .IsUnique();

        // Unique index on WineType.Name
        modelBuilder.Entity<WineType>()
            .HasIndex(wt => wt.Name)
            .IsUnique();
    }
}
