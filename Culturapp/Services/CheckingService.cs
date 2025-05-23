using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;

namespace Culturapp.Services
{
  public class CheckingService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;
    public CheckingService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Checking>> GetAllAsync()
    {
      return await Task.Run(() => _context.Checks);
    }

    public async Task<Checking> GetByIdAsync(int id)
    {
      return await Task.Run(() => _context.Checks.Find(id));
    }

    public async Task<Checking> CreateAsync(Checking checking)
    {
      _context.Checks.Add(checking);
      await _context.SaveChangesAsync();
      return checking;
    }

    public async Task<Checking?> UpdateAsync(Checking checking)
    {
      var existing = _context.Checks.Find(checking.Id);
      if (existing == null)
        return null;

      _context.Entry(existing).CurrentValues.SetValues(checking);
      await _context.SaveChangesAsync();
      return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var checking = _context.Checks.Find(id);
      if (checking == null)
        return false;

      _context.Checks.Remove(checking);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}