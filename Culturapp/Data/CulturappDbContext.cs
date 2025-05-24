using Culturapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Data
{
  public class CulturappDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
  {
    public CulturappDbContext(DbContextOptions<CulturappDbContext> options) : base(options) { }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Checking> Checks { get; set; }
    public DbSet<EnterpriseUser> EnterpriseUsers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<ClientUser> ClientUsers { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Checking)
        .WithOne(c => c.Event)
        .HasForeignKey<Event>(e => e.CheckingId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.LocationAddress)
        .WithOne(l => l.Event)
        .HasForeignKey<Event>(e => e.LocationAddressId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasMany(e => e.Phones)
        .WithOne(p => p.Event)
        .HasForeignKey(p => p.EventId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.FAQ)
        .WithOne(f => f.Event)
        .HasForeignKey<Event>(e => e.FAQId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Event>()
        .HasMany(e => e.ClientUsers)
        .WithMany(u => u.Events)
        .UsingEntity(i => i.ToTable("EventUsers"));

      modelBuilder.Entity<Event>()
        .HasOne(e => e.Status)
        .WithMany(s => s.Events!)
        .HasForeignKey(e => e.StatusId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Event>()
        .HasOne(e => e.EnterpriseUser)
        .WithMany(ent => ent.Events!)
        .HasForeignKey(e => e.EnterpriseId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<EnterpriseUser>()
        .HasOne(o => o.Address)
        .WithOne(a => a.EnterpriseUser)
        .HasForeignKey<EnterpriseUser>(o => o.AddressId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<EnterpriseUser>()
        .HasMany(e => e.Phones)
        .WithOne(p => p.EnterpriseUser)
        .HasForeignKey(p => p.EnterpriseId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Category>()
        .HasMany(c => c.Events)
        .WithOne(e => e.Category)
        .HasForeignKey(e => e.CategoryId)
        .OnDelete(DeleteBehavior.SetNull);

      modelBuilder.Entity<Checking>()
        .HasMany(u => u.ClientUsers)
        .WithMany(c => c.Checks!)
        .UsingEntity(i => i.ToTable("CheckingsUsers"));

      modelBuilder.Entity<Status>()
        .HasMany(s => s.Events)
        .WithOne(e => e!.Status)
        .HasForeignKey(e => e!.StatusId)
        .OnDelete(DeleteBehavior.SetNull);
    }

  }
}
