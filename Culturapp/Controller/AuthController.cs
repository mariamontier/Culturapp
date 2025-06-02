using Microsoft.AspNetCore.Mvc;
using Culturapp.Services;
using Culturapp.Models.Requests;

namespace Culturapp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
      var result = await _authService.RegisterAsync(registerRequest);
      if (result == null)
      {
        return BadRequest();
      }
      else
      {
        return Created();
      }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
      var loginResponse = await _authService.LoginAsync(loginRequest);
      if (loginResponse == null)
      {
        return Unauthorized();
      }
      return Ok(loginResponse);
    }

  }
}
