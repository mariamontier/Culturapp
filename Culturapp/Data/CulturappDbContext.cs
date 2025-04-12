using Culturapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Data
{
  public class CulturappDbContext : DbContext
  {
    public CulturappDbContext(DbContextOptions<CulturappDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Event>().HasKey(e => e.Id);
    }

    internal bool EventExists(int id)
    {
      throw new NotImplementedException();
    }
  }
}
