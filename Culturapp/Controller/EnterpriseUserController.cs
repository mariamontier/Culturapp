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
  public class EnterpriseUserController : ControllerBase
  {
    private readonly EnterpriseUserService _enterpriseUserService;

    public EnterpriseUserController(EnterpriseUserService enterpriseUserService)
    {
      _enterpriseUserService = enterpriseUserService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnterpriseUserById(int id)
    {
      var user = await _enterpriseUserService.GetEnterpriseUserByIdAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEnterpriseUser([FromBody] EnterpriseUserRequest enterpriseUserRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      await _enterpriseUserService.AddEnterpriseUserAsync(enterpriseUserRequest);
      return NoContent();
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateEnterpriseUser([FromBody] EnterpriseUserRequest enterpriseUserRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var updatedUser = await _enterpriseUserService.UpdateEnterpriseUserAsync(enterpriseUserRequest);
      if (updatedUser == null)
      {
        return NotFound();
      }

      return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnterpriseUser(int id)
    {
      var result = await _enterpriseUserService.DeleteEnterpriseUserAsync(id);
      if (result == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}