
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
      var mapperEvent = _mapper.Map<Event>(newEventRequest);
      _context.Events.Add(mapperEvent);
      await _context.SaveChangesAsync();
    }

    public async Task<Event?> UpdateEventAsync(int id, EventRequest eventRequest)
    {
      var eventUpdate = await _context.Events.FindAsync(id);

      if (eventUpdate == null)
      {
        return null;
      }

      eventUpdate.Name = eventRequest.Name;
      eventUpdate.StartDate = eventRequest.StartDate;
      eventUpdate.EndDate = eventRequest.EndDate;
      eventUpdate.Description = eventRequest.Description;
      var locationAddress = await _context.Addresses.FindAsync(eventRequest.LocationAddressId);
      eventUpdate.LocationAddress = locationAddress;
      eventUpdate.Capacity = eventRequest.Capacity;
      eventUpdate.TicketPrice = eventRequest.TicketPrice;
      eventUpdate.SalesStartDate = eventRequest.SalesStartDate;
      eventUpdate.SalesEndDate = eventRequest.SalesEndDate;
      eventUpdate.ScoreValue = eventRequest.ScoreValue;
      var status = await _context.Statuses.FindAsync(eventRequest.StatusId);
      eventUpdate.Status = status;
      var checking = await _context.Checks.FindAsync(eventRequest.CheckingInt);
      eventUpdate.Checking = checking;
      var faq = await _context.FAQs.FindAsync(eventRequest.FAQInt);
      eventUpdate.FAQ = faq;
      var enterprise = await _context.EnterpriseUsers.FindAsync(eventRequest.EnterpriseUserId);
      eventUpdate.Enterprise = enterprise;
      var category = await _context.Categories.FindAsync(eventRequest.CategoryId);
      eventUpdate.Category = category;
      var phones = new List<Phone>();
      if (eventRequest.PhonesId == null)
      {
        eventUpdate.Phones = phones!;
      }
      else
      {
        foreach (var phone in eventRequest.PhonesId!)
        {
          var phoneEntity = await _context.Phones.FindAsync(phone);
          if (phoneEntity != null)
          {
            phones.Add(phoneEntity);
          }
        }
        eventUpdate.Phones = phones!;
      }

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