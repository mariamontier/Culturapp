using Culturapp.Models.Enum;

namespace Culturapp.Models.Requests
{
  public class RegisterRequest
  {
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public AccountType AccountType { get; set; }
    public string? Identifier { get; set; } // CPF or CNPJ
  }
}