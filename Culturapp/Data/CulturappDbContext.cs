using Culturapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Data
{
  public class CulturappDbContext : DbContext
  {
    public CulturappDbContext(DbContextOptions<CulturappDbContext> options) : base(options) { }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Checking> Checks { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Checking)
        .WithOne(c => c.Event)
        .HasForeignKey<Event>(e => e.Checking.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.LocationAddress)
        .WithOne(a => a.Event)
        .HasForeignKey<Event>(e => e.LocationAddress.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasMany(e => e.Phones)
        .WithOne(p => p.Event)
        .HasForeignKey(p => p.Event.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.FAQ)
        .WithOne(f => f.Event)
        .HasForeignKey<Event>(e => e.FAQ.Id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Event>()
        .HasMany(e => e.Users)
        .WithMany(u => u.Events)
        .UsingEntity(i => i.ToTable("EventUsers"));

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Status)
        .WithMany(s => s.Events)
        .HasForeignKey(e => e.Status.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Enterprise)
        .WithMany(ent => ent.Events)
        .HasForeignKey(e => e.Enterprise.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Enterprise>()
        .HasOne(o => o.Address)
        .WithOne(a => a.Enterprise)
        .HasForeignKey<Enterprise>(o => o.Address.Id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Enterprise>()
        .HasMany(e => e.Phones)
        .WithOne(p => p.Enterprise)
        .HasForeignKey(p => p.Enterprise.Id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Category>()
        .HasMany(c => c.Events)
        .WithOne(e => e.Category)
        .HasForeignKey(e => e.Category.Id)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Checking>()
        .HasMany(u => u.Users)
        .WithMany(c => c.Checks)
        .UsingEntity(i => i.ToTable("CheckingsUsers"));
    }

  }
}
