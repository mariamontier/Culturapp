using Culturapp.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace Culturapp.Models
{
  public class ApplicationUser : IdentityUser
  {
    public AccountType AccountType { get; set; }
    public string? CNPJ { get; set; }
    public string? CPF { get; set; }
  }
}