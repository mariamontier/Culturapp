using Microsoft.AspNetCore.Mvc;
using Culturapp.Services;
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

    [HttpGet("GetClientUsers")]
    public async Task<IActionResult> GetClientUsers()
    {
      var users = await _clientUserService.GetClientUsersAsync();
      return Ok(users);
    }

    [HttpGet("GetClientUserById/{id}")]
    public async Task<IActionResult> GetClientUserById(int id)
    {
      var user = await _clientUserService.GetClientUserByIdAsync(id);
      if (user == null)
        return NotFound();

      return Ok(user);
    }

    [HttpPut("PutClientUser/{id}")]
    public async Task<IActionResult> PutClientUser(int id, [FromBody] ClientUserRequest clientUserRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updatedUser = await _clientUserService.UpdateClientUserAsync(clientUserRequest);
      if (updatedUser == null)
        return NotFound();

      return Ok(updatedUser);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deleted = await _clientUserService.DeleteClientUserAsync(id);
      if (deleted == null)
        return NotFound();

      return NoContent();
    }
  }
}