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
      var events = await _context.Events.Include(e => e.Status).Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
      var eventResponse = _mapper.Map<EventResponse>(events);
      return eventResponse;
    }

    public async Task CreateEventAsync(EventRequest newEventRequest)
    {
      var eventNew = new Event();
      eventNew = await MakeEventRelationshipMapper(eventNew, newEventRequest);
      eventNew.ScoreValue = eventNew.TicketPrice * 0.10;
      _context.Events.Add(eventNew);
      await _context.SaveChangesAsync();
    }

    public async Task<Event?> UpdateEventAsync(int id, EventRequest? eventRequest)
    {
      var eventUpdate = await _context.Events.FindAsync(id);

      if (eventUpdate == null || eventRequest == null)
      {
        return null;
      }

      bool ticketPriceChanged = eventRequest.TicketPrice != eventUpdate.TicketPrice;

      eventUpdate = await MakeEventRelationshipMapper(eventUpdate, eventRequest);

      if (ticketPriceChanged)
      {
        eventUpdate.ScoreValue = eventUpdate.TicketPrice * 0.10;
      }
      _context.Events.Update(eventUpdate);
      await _context.SaveChangesAsync();

      return eventUpdate;
    }

    public async Task DeleteEventAsync(int id)
    {
      var eventDelete = await _context.Events.FindAsync(id);
      if (eventDelete != null)
      {
        var eventToDelete = _mapper.Map<Event>(eventDelete);
        _context.Events.Remove(eventToDelete);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<Event> MakeEventRelationshipMapper(Event? bestEvent, EventRequest? eventRequest)
    {
      if (bestEvent == null || eventRequest == null) return null!;

      bestEvent.Name = eventRequest.Name;
      bestEvent.StartDate = eventRequest.StartDate;
      bestEvent.EndDate = eventRequest.EndDate;
      bestEvent.Description = eventRequest.Description;
      bestEvent.LocationAddress = await _context.Addresses.FindAsync(eventRequest.LocationAddressId);
      bestEvent.Capacity = eventRequest.Capacity;
      bestEvent.TicketPrice = eventRequest.TicketPrice;
      bestEvent.SalesStartDate = eventRequest.SalesStartDate;
      bestEvent.SalesEndDate = eventRequest.SalesEndDate;
      bestEvent.ScoreValue = eventRequest.ScoreValue;
      bestEvent.Status = await _context.Statuses.FindAsync(eventRequest.StatusId);
      bestEvent.Checking = await _context.Checks.FindAsync(eventRequest.CheckingInt);
      bestEvent.FAQ = await _context.FAQs.FindAsync(eventRequest.FAQInt);
      bestEvent.Enterprise = await _context.EnterpriseUsers.FindAsync(eventRequest.EnterpriseUserId);
      bestEvent.Category = await _context.Categories.FindAsync(eventRequest.CategoryId);

      // Phones
      if (eventRequest.PhonesId != null && eventRequest.PhonesId.Any())
      {
        var phones = new List<Phone>();
        foreach (var phoneId in eventRequest.PhonesId)
        {
          var phoneEntity = await _context.Phones.FindAsync(phoneId);
          if (phoneEntity != null)
          {
            phones.Add(phoneEntity);
          }
        }
        bestEvent.Phones = phones;
      }

      // ClientUsers
      if (eventRequest.ClientUsersId != null && eventRequest.ClientUsersId.Any())
      {
        var clientUsersList = new List<ClientUser>();
        foreach (var clientUserId in eventRequest.ClientUsersId)
        {
          if (clientUserId == null) continue;

          var clientUserEntity = await _context.ClientUsers.FindAsync(clientUserId);
          if (clientUserEntity != null)
          {
            clientUsersList.Add(clientUserEntity);
          }
        }
        bestEvent.ClientUsers = clientUsersList!;
      }

      return bestEvent;
    }


  }
}