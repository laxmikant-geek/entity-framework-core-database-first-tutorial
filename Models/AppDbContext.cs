using Microsoft.EntityFrameworkCore;

namespace DbFirstSample.Models;

// Representative of a scaffolded DbContext produced with --no-onconfiguring:
// no connection string is baked in; options are supplied by the caller.
public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        OnModelCreatingPartial(modelBuilder);
    }

    // Implement this in your own file to add configuration that survives --force.
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
