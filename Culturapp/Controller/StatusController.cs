using Culturapp.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Culturapp.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class StatusController : ControllerBase
  {
    private readonly StatusService _statusService;

    public StatusController(StatusService statusService)
    {
      _statusService = statusService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStatuses()
    {
      var statuses = await _statusService.GetStatusesAsync();
      if (statuses == null || !statuses.Any())
      {
        return NotFound();
      }
      return Ok(statuses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
      var status = await _statusService.GetStatusByIdAsync(id);
      if (status == null)
      {
        return NotFound();
      }
      return Ok(status);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStatus([FromBody] StatusRequest newStatus)
    {
      if (newStatus == null)
      {
        return BadRequest();
      }

      var result = await _statusService.CreateStatusAsync(newStatus);
      if (!result)
      {
        return BadRequest();
      }
      return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStatus(int id, [FromBody] StatusRequest? updatedStatus)
    {
      if (updatedStatus == null)
      {
        return BadRequest();
      }

      var result = await _statusService.UpdateStatusAsync(id, updatedStatus);
      if (!result)
      {
        return NotFound();
      }
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
      var result = await _statusService.DeleteStatusAsync(id);
      if (!result)
      {
        return NotFound();
      }
      return NoContent();
    }
  }
}