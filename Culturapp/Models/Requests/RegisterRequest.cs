using System.ComponentModel.DataAnnotations;
using Culturapp.Models.Enum;

namespace Culturapp.Models.Requests
{
  public class RegisterRequest
  {
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public AccountType AccountType { get; set; }

    [StringLength(14, MinimumLength = 14)]
    public string? CNPJ { get; set; }

    [StringLength(11, MinimumLength = 11)]
    public string? CPF { get; set; }
  }
}