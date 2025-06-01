using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.EntityFrameworkCore;

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
    var statuses = await _context.Statuses.Include(s => s.Events).ToListAsync();
    return _mapper.Map<ICollection<StatusResponse>>(statuses);
  }

  public async Task<StatusResponse?> GetStatusByIdAsync(int id)
  {
    var status = await _context.Statuses.Include(s => s.Events).FirstOrDefaultAsync(s => s.Id == id);
    if (status == null) return null;
    return _mapper.Map<StatusResponse>(status);
  }

  public async Task<bool> CreateStatusAsync(StatusRequest newStatus)
  {

    var statusExistsAny = await _context.Statuses.AnyAsync();

    if (!statusExistsAny)
    {
      var defaultStatuses = new List<Status>
      {
        new Status { StatusName = "Aberto" },
        new Status { StatusName = "Ativo" },
        new Status { StatusName = "Cancelado" },
        new Status { StatusName = "Adiado" },
        new Status { StatusName = "Esgotado" },
        new Status { StatusName = "Finalizado" },
        new Status { StatusName = "Em Preparação" },
      };

      _context.Statuses.AddRange(defaultStatuses);
      await _context.SaveChangesAsync();
      return true;
    }

    if (newStatus == null)
      return false;

    var exists = await _context.Statuses
                               .AnyAsync(s => s.StatusName == newStatus.StatusName);
    if (exists)
    {
      return false;
    }

    var statusNew = _mapper.Map<Status>(newStatus);
    _context.Statuses.Add(statusNew);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> UpdateStatusAsync(int? id, StatusRequest? updatedStatus)
  {
    var status = await _context.Statuses.FindAsync(id);
    if (status == null)
      return false;

    _mapper.Map(updatedStatus, status);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteStatusAsync(int id)
  {
    var status = await _context.Statuses.FindAsync(id);
    if (status == null)
      return false;

    _context.Statuses.Remove(status);
    await _context.SaveChangesAsync();
    return true;
  }
}
