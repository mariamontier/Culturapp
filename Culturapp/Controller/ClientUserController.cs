using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Culturapp.Services;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Culturapp.Controller
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ClientUserController : ControllerBase
  {
    private readonly ClientUserService _clientUserService;

    public ClientUserController(ClientUserService clientUserService)
    {
      _clientUserService = clientUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var users = await _clientUserService.GetClientUsersAsync();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var user = await _clientUserService.GetClientUserByIdAsync(id);
      if (user == null)
        return NotFound();

      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientUserRequest clientUserRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var createdUser = await _clientUserService.CreateClientUserAsync(clientUserRequest);
      return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClientUserRequest clientUserRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updatedUser = await _clientUserService.UpdateClientUserAsync(clientUserRequest);
      if (updatedUser == null)
        return NotFound();

      return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deleted = await _clientUserService.DeleteClientUserAsync(id);
      if (deleted == null)
        return NotFound();

      return NoContent();
    }
  }
}