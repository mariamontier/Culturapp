using Culturapp.Models.Enum;

namespace Culturapp.Models.Requests
{
  public class RegisterRequest
  {
    public string? UserName { get; set; }
    public string? UserFullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public AccountType AccountType { get; set; }
    public string? CNPJ { get; set; }
    public string? CPF { get; set; }
  }
}