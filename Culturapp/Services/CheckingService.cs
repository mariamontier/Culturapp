using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<CheckingResponse>> GetAllAsync()
    {
      var checks = await _context.Checks.Include(c => c.Event).Include(c => c.ClientUsers).ToListAsync();
      var mappedChecks = _mapper.Map<IEnumerable<Checking>>(checks);
      var mappedCheckingResponses = _mapper.Map<IEnumerable<CheckingResponse>>(mappedChecks);
      return mappedCheckingResponses;
    }

    public async Task<Checking?> GetByIdAsync(int id)
    {
      var checking = await _context.Checks.Include(c => c.Event).Include(c => c.ClientUsers).FirstOrDefaultAsync(c => c.Id == id);
      var mappedChecking = _mapper.Map<Checking>(checking);
      return mappedChecking!;
    }

    public async Task<CheckingResponse?> UpdateAsync(int id, CheckingRequest checking)
    {
      var existing = await _context.Checks.FirstOrDefaultAsync(c => c.Id == id);
      if (existing == null)
        return null;

      _mapper.Map(checking, existing);
      await _context.SaveChangesAsync();
      var mappedCheckingResponse = _mapper.Map<CheckingResponse>(existing);
      return mappedCheckingResponse!;
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