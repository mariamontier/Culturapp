using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Culturapp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
      _eventService = eventService;
    }


    [HttpGet("GetEvents")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var listEvent = await _eventService.GetAllEventsAsync();
      return Ok(listEvent);
    }

    [HttpGet("GetEvent/{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
      var eventItem = await _eventService.GetEventByIdAsync(id);

      if (eventItem == null)
      {
        return NotFound();
      }

      return Ok(eventItem);
    }

    [Authorize]
    [HttpPost("PostEvent")]
    public async Task<ActionResult<Event>> PostEvent(EventRequest eventItem)
    {

      if (eventItem == null)
      {
        return BadRequest();
      }

      var eventCreate = await _eventService.CreateEventAsync(eventItem);

      if (eventCreate == null)
      {
        return BadRequest();
      }

      return Created();

    }

    [Authorize]
    [HttpPut("PutEvent/{id}")]
    public async Task<IActionResult> PutEvent(int id, EventRequest eventItem)
    {
      await _eventService.UpdateEventAsync(id, eventItem);

      return NoContent();
    }

    [Authorize]
    [HttpDelete("DeleteEvent/{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
      var eventItem = await _eventService.GetEventByIdAsync(id)!;
      if (eventItem == null)
      {
        return NotFound();
      }

      await _eventService.DeleteEventAsync(id);

      return NoContent();
    }

    [HttpGet("GetEventByName/{name}")]
    public async Task<ActionResult> GetEventByName(string name)
    {
      var eventItem = await _eventService.GetEventByNameAsync(name);
      if (eventItem == null)
      {
        return NotFound();
      }

      return Ok(eventItem);
    }

    [HttpGet("GetEventByEnterprise/{enterpriseId}")]
    public async Task<ActionResult> GetEventByEnterprise(int enterpriseId)
    {
      var eventItem = await _eventService.GetEventByEnterpriseIdAsync(enterpriseId);
      if (eventItem == null)
      {
        return NotFound();
      }

      return Ok(eventItem);
    }

  }
}