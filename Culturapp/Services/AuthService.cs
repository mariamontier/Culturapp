
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Culturapp.Services
{
  public class AuthService
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        IMapper mapper)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
      _mapper = mapper;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterRequest registerRequest)
    {
      if (string.IsNullOrEmpty(registerRequest.Password))
      {
        throw new ArgumentException("Password cannot be null or empty.");
      }

      var user = _mapper.Map<ApplicationUser>(registerRequest);

      return await _userManager.CreateAsync(user, registerRequest.Password);
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest loginRequest)
    {
      if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
      {
        throw new ArgumentException("Identifier and Password cannot be null or empty.");
      }

      var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CPF == loginRequest.Email || u.Email == loginRequest.Email);

      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user.UserName!, loginRequest.Password, false, false);

        if (result.Succeeded)
        {
          var token = GenerateToken(user.UserName!, user.AccountType.ToString());
          return new LoginResponse
          {
            Token = token,
            Username = user.UserName,
            AccountType = user.AccountType.ToString()
          };
        }
      }

      return null;
    }

    private string GenerateToken(string username, string accountType)
    {
      var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("AccountType", accountType),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

      var authSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured."))
      );

      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          audience: _configuration["Jwt:Audience"],
          expires: DateTime.UtcNow.AddHours(1),
          claims: authClaims,
          signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task LogoutAsync()
    {
      await _signInManager.SignOutAsync();
    }
  }
}
