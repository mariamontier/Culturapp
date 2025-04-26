using Culturapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Data
{
  public class CulturappDbContext : DbContext
  {
    public CulturappDbContext(DbContextOptions<CulturappDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Checking> Checks { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Address)
        .WithOne(a => a.Event)
        .HasForeignKey<Address>(a => a.EventId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Event>()
        .HasOne(c => c.Category)
        .WithMany(e => e.Events)
        .HasForeignKey(e => e.CategoryId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Checking)
        .WithOne(c => c.Event)
        .HasForeignKey<Checking>(e => e.EventId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Enterprise>()
        .HasOne(o => o.Address)
        .WithOne(a => a.Enterprise)
        .HasForeignKey<Address>(a => a.EnterpriseId)
        .OnDelete(DeleteBehavior.Cascade);

    }

  }
}
