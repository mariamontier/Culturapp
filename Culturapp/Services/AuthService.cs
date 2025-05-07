
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
      var user = _mapper.Map<ApplicationUser>(registerRequest);

      return await _userManager.CreateAsync(user, registerRequest.Password!);
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest loginRequest)
    {
      if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
      {
        throw new ArgumentException("Email and Password cannot be null or empty.");
      }

      var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user.UserName!, loginRequest.Password, false, false);

        if (result.Succeeded)
        {
          var token = GenerateToken(user);
          return new LoginResponse
          {
            Token = token,
            Identifier = user.CPF ?? user.CNPJ,
            AccountType = user.AccountType.ToString()
          };
        }
      }

      return null;
    }

    private string GenerateToken(ApplicationUser? user)
    {
      var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user?.UserName!),
                new Claim(ClaimTypes.Email, user?.Email!),
                new Claim("AccountType", user?.AccountType.ToString()!),
                new Claim(ClaimTypes.NameIdentifier, user?.Id!),
                new Claim(JwtRegisteredClaimNames.Sub, user?.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

      var authSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured."))
      );

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(authClaims),
        Expires = DateTime.UtcNow.AddHours(1),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var securityToken = tokenHandler.CreateToken(tokenDescriptor);
      string tokenString = tokenHandler.WriteToken(securityToken);

      return tokenString;

    }

    public async Task<ApplicationUser?> FindUser(string email)
    {
      var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
      return user;
    }

  }
}
