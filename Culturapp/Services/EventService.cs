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
      var eventGet = await _context.Events
          .Include(e => e.LocationAddress)
          .Include(e => e.Phones)
          .Include(e => e.ClientUsers)
          .Include(e => e.Checking)
          .Include(e => e.FAQ)
          .Include(e => e.Status)
          .Include(e => e.Category)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Address)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Phones)
          .ToListAsync();
      var eventResponse = _mapper.Map<ICollection<EventResponse>>(eventGet);
      return eventResponse;
    }

    public async Task<EventResponse?> GetEventByIdAsync(int id)
    {
      var eventGet = await _context.Events
          .Include(e => e.LocationAddress)
          .Include(e => e.Phones)
          .Include(e => e.ClientUsers)
          .Include(e => e.Checking)
          .Include(e => e.FAQ)
          .Include(e => e.Status)
          .Include(e => e.Category)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Address)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Phones)
          .FirstOrDefaultAsync(e => e.Id == id);

      if (eventGet == null)
        return null;

      var eventResponse = _mapper.Map<EventResponse>(eventGet);
      return eventResponse;
    }


    public async Task<string?> CreateEventAsync(EventRequest newEventRequest)
    {
      var eventNew = new Event();

      eventNew = await MakeEventRelationshipMapper(eventNew, newEventRequest);

      if (eventNew == null)
      {
        return null;
      }

      eventNew!.ScoreValue = eventNew.TicketPrice * 0.10;
      _context.Events.Add(eventNew);
      await _context.SaveChangesAsync();

      var checking = await CreateCheckingAsync(eventNew);
      eventNew.Checking = checking;

      await _context.SaveChangesAsync();

      return "Event created";

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
        eventUpdate!.ScoreValue = eventUpdate.TicketPrice * 0.10;
      }
      _context.Events.Update(eventUpdate!);
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

    public async Task<Event?> MakeEventRelationshipMapper(Event? bestEvent, EventRequest? eventRequest)
    {
      if (bestEvent == null || eventRequest == null) return null;

      bestEvent.Name = eventRequest.Name;
      bestEvent.StartDate = eventRequest.StartDate;
      bestEvent.EndDate = eventRequest.EndDate;
      bestEvent.Description = eventRequest.Description;
      bestEvent.LocationAddress = await _context.Addresses.FindAsync(eventRequest.LocationAddressId);
      bestEvent.Capacity = eventRequest.Capacity;
      bestEvent.TicketPrice = eventRequest.TicketPrice;
      bestEvent.SalesStartDate = eventRequest.SalesStartDate;
      bestEvent.SalesEndDate = eventRequest.SalesEndDate;
      bestEvent.Status = await _context.Statuses.FindAsync(eventRequest.StatusId);
      bestEvent.Checking = await _context.Checks.FindAsync(eventRequest.Checking);
      bestEvent.FAQ = await _context.FAQs.FindAsync(eventRequest.FAQInt);
      bestEvent.EnterpriseUser = await _context.EnterpriseUsers.FindAsync(eventRequest.EnterpriseUserId);
      bestEvent.Category = await _context.Categories.FindAsync(eventRequest.CategoryId);

      // Phones - substitui todos os anteriores
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
        bestEvent.Phones = phones!;
      }

      if (eventRequest.ClientUsersId != null && eventRequest.ClientUsersId.Any())
      {
        // Carrega o evento atual com os usuários
        var currentEvent = await _context.Events
            .Include(e => e.ClientUsers)
            .FirstOrDefaultAsync(e => e.Id == bestEvent.Id);

        var existingUserIds = currentEvent?.ClientUsers?.Select(u => u!.Id).ToHashSet() ?? new HashSet<int>();
        var newClientUsers = new List<ClientUser>();

        foreach (var clientUserId in eventRequest.ClientUsersId)
        {
          if (clientUserId == null || existingUserIds.Contains(clientUserId.Value))
            continue;

          var clientUserEntity = await _context.ClientUsers.FindAsync(clientUserId);
          if (clientUserEntity != null)
          {
            newClientUsers.Add(clientUserEntity);
          }
        }

        if (bestEvent.ClientUsers == null || !bestEvent.ClientUsers.Any())
        {
          bestEvent.ClientUsers = newClientUsers!;
        }
        else
        {
          foreach (var client in newClientUsers)
          {
            bestEvent.ClientUsers.Add(client);
          }
        }
      }

      return bestEvent;
    }

    public async Task<List<EventResponse>?> GetEventByNameAsync(string name)
    {
      var eventGet = await _context.Events
          .Include(e => e.LocationAddress)
          .Include(e => e.Phones)
          .Include(e => e.ClientUsers)
          .Include(e => e.Checking)
          .Include(e => e.FAQ)
          .Include(e => e.Status)
          .Include(e => e.Category)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Address)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Phones)
          .Where(e => EF.Functions.Like(e.Name, $"%{name}%"))
          .OrderByDescending(e => e.StartDate)
          .ToListAsync();
      if (eventGet == null || !eventGet.Any())
        return null;

      var eventResponse = _mapper.Map<List<EventResponse>>(eventGet);
      return eventResponse;
    }

    public async Task<List<EventResponse?>?> GetEventByEnterpriseIdAsync(int id)
    {
      var eventGet = await _context.Events
          .Where(e => e.EnterpriseId == id)
          .Include(e => e.LocationAddress)
          .Include(e => e.Phones)
          .Include(e => e.ClientUsers)
          .Include(e => e.Checking)
          .Include(e => e.FAQ)
          .Include(e => e.Status)
          .Include(e => e.Category)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Address)
          .Include(e => e.EnterpriseUser)
              .ThenInclude(ent => ent!.Phones)
          .ToListAsync();
      if (eventGet == null || !eventGet.Any())
        return null;

      var eventResponse = _mapper.Map<List<EventResponse>>(eventGet);
      return eventResponse!;
    }

    public async Task<Checking?> CreateCheckingAsync(Event eventEntity)
    {
      if (eventEntity == null) return null;

      var checking = new Checking
      {
        CheckingDate = eventEntity.EndDate?.AddDays(1), // Assuming checking date is the day after the event ends
        Event = eventEntity,
        ClientUsers = new List<ClientUser?>()
      };

      _context.Checks.Add(checking);
      await _context.SaveChangesAsync();

      return checking;
    }

  }
}