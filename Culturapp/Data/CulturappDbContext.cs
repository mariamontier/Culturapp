using Culturapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Data
{
  public class CulturappDbContext : DbContext
  {

    public DbSet<Event> Events { get; set; } = null!;

    public CulturappDbContext(DbContextOptions<CulturappDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>().HasKey(e => e.Id);
    }
  }
}