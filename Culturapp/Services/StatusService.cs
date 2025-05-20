using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class StatusService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;

    public StatusService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ICollection<StatusResponse>> GetStatusesAsync()
    {
      var status = await _context.Statuses.ToListAsync();
      var statusResponse = _mapper.Map<ICollection<StatusResponse>>(status);
      return statusResponse;
    }

    public async Task<StatusResponse?> GetStatusByIdAsync(int id)
    {
      var status = await _context.Statuses.FindAsync(id);
      var statusResponse = _mapper.Map<StatusResponse>(status);
      return statusResponse;
    }

    public async Task CreateStatusAsync(StatusResponse newStatus)
    {
      var statusNew = _mapper.Map<Status>(newStatus);
      _context.Statuses.Add(statusNew);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(int id, StatusResponse updatedStatus)
    {
      var status = await _context.Statuses.FindAsync(id);
      if (status != null)
      {
        _mapper.Map(updatedStatus, status);
        await _context.SaveChangesAsync();
      }
    }

    public async Task Delete(int id)
    {
      var status = await _context.Statuses.FindAsync(id);
      if (status != null)
      {
        _context.Statuses.Remove(status);
        await _context.SaveChangesAsync();
      }
    }
  }
}