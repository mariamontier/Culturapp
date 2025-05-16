
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

    public async Task CreateEventAsync(EventRequest newEventRequest)
    {
      var eventNew = new Event();
      eventNew = await MakeEventRelationshipMapper(eventNew, newEventRequest);
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

      eventUpdate = await MakeEventRelationshipMapper(eventUpdate, eventRequest);

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
      bestEvent!.Name = eventRequest!.Name;
      bestEvent.StartDate = eventRequest.StartDate;
      bestEvent.EndDate = eventRequest.EndDate;
      bestEvent.Description = eventRequest.Description;
      var locationAddress = await _context.Addresses.FindAsync(eventRequest.LocationAddressId);
      bestEvent.LocationAddress = locationAddress;
      bestEvent.Capacity = eventRequest.Capacity;
      bestEvent.TicketPrice = eventRequest.TicketPrice;
      bestEvent.SalesStartDate = eventRequest.SalesStartDate;
      bestEvent.SalesEndDate = eventRequest.SalesEndDate;
      bestEvent.ScoreValue = eventRequest.ScoreValue;
      var status = await _context.Statuses.FindAsync(eventRequest.StatusId);
      bestEvent.Status = status;
      var checking = await _context.Checks.FindAsync(eventRequest.CheckingInt);
      bestEvent.Checking = checking;
      var faq = await _context.FAQs.FindAsync(eventRequest.FAQInt);
      bestEvent.FAQ = faq;
      var enterprise = await _context.EnterpriseUsers.FindAsync(eventRequest.EnterpriseUserId);
      bestEvent.Enterprise = enterprise;
      var category = await _context.Categories.FindAsync(eventRequest.CategoryId);
      bestEvent.Category = category;

      var eventCheck = await _context.Events.FindAsync(bestEvent.Id)!;

      ICollection<Phone?> phones = new List<Phone?>();
      ICollection<ClientUser?> clientUsers = new List<ClientUser?>();

      if (eventCheck!.Phones! != null)
      {
        phones = eventCheck!.Phones!;
      }

      if (eventCheck.ClientUsers != null)
      {
        clientUsers = eventCheck.ClientUsers;
      }

      if (eventRequest.PhonesId == null)
      {
        bestEvent.Phones = phones!;
      }
      else
      {
        foreach (var phone in eventRequest.PhonesId!)
        {
          var phoneEntity = await _context.Phones.FindAsync(phone);
          if (phoneEntity != null)
          {
            phones!.Add(phoneEntity);
          }
        }
        bestEvent.Phones = phones!;
      }


      if (eventRequest.ClientUsersId == null)
      {
        bestEvent.ClientUsers = clientUsers!;
      }
      else
      {
        foreach (var clientUserId in eventRequest.ClientUsersId!)
        {
          var clientUserEntity = await _context.ClientUsers.FindAsync(clientUserId);
          if (clientUserEntity != null)
          {
            clientUsers.Add(clientUserEntity);
          }
        }
        bestEvent.ClientUsers = clientUsers!; // check a error when add a clientUser
      }

      return bestEvent;
    }

  }
}