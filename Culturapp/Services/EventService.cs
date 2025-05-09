
using AutoMapper;
using Culturapp.Data;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
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

    public async Task<ICollection<EventResponse>> GetAllEventsAsync()
    {
      var events = await _context.Events.ToListAsync();
      var eventResponse = _mapper.Map<ICollection<EventResponse>>(events);
      return eventResponse;
    }

    public async Task<EventResponse?> GetEventByIdAsync(int id)
    {
      var events = await _context.Events.FindAsync(id);
      var eventResponse = _mapper.Map<EventResponse>(events);
      return eventResponse;
    }

    public async Task AddEventAsync(EventRequest newEventRequest)
    {
      var mapperEvent = _mapper.Map<Event>(newEventRequest);
      _context.Events.Add(mapperEvent);
      await _context.SaveChangesAsync();
    }

    public async Task<Event?> UpdateEventAsync(int id, EventRequest eventRequest)
    {

      var eventUpdateResponse = await GetEventByIdAsync(id)!;
      var eventUpdate = _mapper.Map<Event>(eventUpdateResponse);

      if (eventUpdate == null)
      {
        return null;
      }

      eventUpdate.Name = eventRequest.Name;
      eventUpdate.StartDate = eventRequest.StartDate;
      eventUpdate.EndDate = eventRequest.EndDate;
      eventUpdate.Description = eventRequest.Description;
      eventUpdate.LocationAddressId = eventRequest.LocationAddressId;
      eventUpdate.Capacity = eventRequest.Capacity;
      eventUpdate.TicketPrice = eventRequest.TicketPrice;
      eventUpdate.SalesStartDate = eventRequest.SalesStartDate;
      eventUpdate.SalesEndDate = eventRequest.SalesEndDate;
      eventUpdate.ScoreValue = eventRequest.ScoreValue;
      eventUpdate.StatusId = eventRequest.StatusInt;
      eventUpdate.CheckingId = eventRequest.CheckingInt;
      eventUpdate.FAQId = eventRequest.FAQInt;
      eventUpdate.EnterpriseId = eventRequest.EnterpriseUserId;
      eventUpdate.CategoryId = eventRequest.CategoryId;

      _context.Events.Update(eventUpdate);
      await _context.SaveChangesAsync();

      return eventUpdate;
    }

    public async Task DeleteEventAsync(int id)
    {
      var eventResponse = await GetEventByIdAsync(id);
      if (eventResponse != null)
      {
        var eventToDelete = _mapper.Map<Event>(eventResponse);
        _context.Events.Remove(eventToDelete);
        await _context.SaveChangesAsync();
      }
    }

  }
}