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
    private readonly EventServe _context;

    public EventController(EventServe context)
    {
      _context = context;
    }


    [HttpGet("GetEvents")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var listEvent = await _context.GetAllEventsAsync();
      return Ok(listEvent);
    }

    [HttpGet("GetEvent/{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
      var eventItem = await _context.GetEventByIdAsync(id);

      if (eventItem == null)
      {
        return NotFound();
      }

      return Ok(eventItem);
    }

    [HttpPost("PostEvent")]
    public async Task<ActionResult<Event>> PostEvent(EventRequest eventItem)
    {

      await _context.AddEventAsync(eventItem);
      if (eventItem == null)
      {
        return BadRequest();
      }

      return NoContent();

    }

    [HttpPut("PutEvent/{id}")]
    public async Task<IActionResult> PutEvent(int id, EventRequest eventItem)
    {
      var eventExists = await _context.EventExists(id)!;

      if (eventExists == null)
      {
        return NotFound();
      }

      var updatedEvent = new Event
      {
        Name = eventItem.Name,
        Date = eventItem.Date,
        Description = eventItem.Description,
        Location = eventItem.Location,
        Capacity = eventItem.Capacity,
        Price = eventItem.Price
      };

      eventExists = updatedEvent;
      eventExists.Id = id;

      await _context.UpdateEventAsync(updatedEvent);

      return NoContent();
    }

    [HttpDelete("DeleteEvent/{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
      var eventItem = await _context.EventExists(id)!;
      if (eventItem == null)
      {
        return NotFound();
      }

      await _context.DeleteEventAsync(id);

      return NoContent();
    }


  }
}