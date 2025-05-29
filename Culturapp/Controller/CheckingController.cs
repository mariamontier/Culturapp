using Microsoft.AspNetCore.Mvc;
using Culturapp.Models;
using Culturapp.Services;
using Culturapp.Models.Requests;

namespace Culturapp.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class CheckingController : ControllerBase
  {
    private readonly CheckingService _checkingService;

    public CheckingController(CheckingService checkingService)
    {
      _checkingService = checkingService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Checking>> GetById(int id)
    {
      var checking = await _checkingService.GetByIdAsync(id);
      if (checking == null)
        return NotFound();
      return Ok(checking);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Checking>>> GetAll()
    {
      var checkings = await _checkingService.GetAllAsync();
      return Ok(checkings);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CheckingRequest checking)
    {
      if (id == 0 || checking == null)
        return BadRequest();

      var updated = await _checkingService.UpdateAsync(id, checking);
      if (updated == null)
        return NotFound();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deleted = await _checkingService.DeleteAsync(id);
      if (!deleted)
        return NotFound();

      return NoContent();
    }
  }
}