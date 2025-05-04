
using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Culturapp.Services
{
  public class EventService
  {
    private readonly CulturappDbContext _context;
    private readonly IMapper _mapper;
    public EventService(CulturappDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ICollection<Event>> GetAllEventsAsync()
    {
      return await _context.Events.ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
      return await _context.Events.FindAsync(id);
    }

    public async Task AddEventAsync(EventRequest newEventRequest)
    {
      var mapperEvent = _mapper.Map<Event>(newEventRequest);
      _context.Events.Add(mapperEvent);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(Event updatedEvent)
    {
      _context.Events.Update(updatedEvent);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
      var eventToDelete = await GetEventByIdAsync(id);
      if (eventToDelete != null)
      {
        _context.Events.Remove(eventToDelete);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<Event?> EventExists(int id)
    {
      var foundEvent = await _context.Events.FindAsync(id);
      return foundEvent;
    }

  }
}