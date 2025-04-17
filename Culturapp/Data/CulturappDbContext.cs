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
    public DbSet<Customer> Costumers { get; set; }
    public DbSet<EventLocation> EventLocations { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }

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
        .WithOne(e => e.Event)
        .HasForeignKey<Category>(e => e.EventId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Checking)
        .WithOne(c => c.Event)
        .HasForeignKey<Checking>(e => e.EventId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Company>()
        .HasOne(o => o.Address)
        .WithOne(a => a.Company)
        .HasForeignKey<Address>(a => a.CompanyId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Customer>()
        .HasOne(c => c.Address)
        .WithOne(a => a.Customer)
        .HasForeignKey<Address>(a => a.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Customer>()
        .HasMany(c => c.Checks)
        .WithOne(c => c.Customer)
        .HasForeignKey(c => c.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);


    }

  }
}
