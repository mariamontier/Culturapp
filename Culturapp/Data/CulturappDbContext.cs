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
    public DbSet<Checking> Checkings { get; set; }
    public DbSet<Customer> Costumers { get; set; }
    public DbSet<EventLocation> EventLocations { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>().HasKey(e => e.Id);
      modelBuilder.Entity<Address>().HasKey(e => e.Id);
      modelBuilder.Entity<Category>().HasKey(e => e.Id);
      modelBuilder.Entity<Checking>().HasKey(e => e.Id);
      modelBuilder.Entity<Customer>().HasKey(e => e.Id);
      modelBuilder.Entity<EventLocation>().HasKey(e => e.Id);
      modelBuilder.Entity<Faq>().HasKey(e => e.Id);
      modelBuilder.Entity<Organizer>().HasKey(e => e.Id);
      modelBuilder.Entity<User>().HasKey(e => e.Id);


    }

  }
}
