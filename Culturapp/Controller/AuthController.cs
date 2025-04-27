using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Culturapp.Models;
using Culturapp.Services;
using System.Threading.Tasks;
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
      if (result.Succeeded)
      {
        return Ok(new { Message = "User created successfully" });
      }
      return BadRequest(result.Errors);
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


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
      await _authService.LogoutAsync();
      return Ok(new { Message = "Logged out successfully" });
    }

  }
}
