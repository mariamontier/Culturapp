using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Serves;
using Microsoft.AspNetCore.Mvc;

namespace Culturapp.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly EventServe _eventServe;

    public EventController(EventServe eventServe)
    {
      _eventServe = eventServe;
    }


    [HttpGet("GetEvents")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var listEvent = await _eventServe.GetAllEventsAsync();
      return Ok(listEvent);
    }

    [HttpGet("GetEvent/{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
      var eventItem = await _eventServe.GetEventByIdAsync(id);

      if (eventItem == null)
      {
        return NotFound();
      }

      return Ok(eventItem);
    }

    [HttpPost("PostEvent")]
    public async Task<ActionResult<Event>> PostEvent(EventRequest eventItem)
    {

      await _eventServe.AddEventAsync(eventItem);
      if (eventItem == null)
      {
        return BadRequest();
      }

      return NoContent();

    }

    [HttpPut("PutEvent/{id}")]
    public async Task<IActionResult> PutEvent(int id, EventRequest eventItem)
    {
      var eventExists = await _eventServe.EventExists(id)!;

      if (eventExists == null)
      {
        return NotFound();
      }

      var updatedEvent = new Event
      {
        Id = eventExists.Id,
        Name = eventItem.Name,
        Description = eventItem.Description,
        Category = eventItem.Category,
        LocationAddress = eventItem.LocationAddress,
        Phones = eventItem.Phones,
        FAQ = eventItem.FAQ,
        Checking = eventItem.Checking,
        Status = eventExists.Status,
        Enterprise = eventExists.Enterprise
      };

      eventExists = updatedEvent;
      eventExists.Id = id;

      await _eventServe.UpdateEventAsync(updatedEvent);

      return NoContent();
    }

    [HttpDelete("DeleteEvent/{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
      var eventItem = await _eventServe.EventExists(id)!;
      if (eventItem == null)
      {
        return NotFound();
      }

      await _eventServe.DeleteEventAsync(id);

      return NoContent();
    }


  }
}