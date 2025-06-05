using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class PhoneRequest
  {
    public string? CountryCode { get; set; }
    public string? AreaCode { get; set; }

    // [StringLength(9, MinimumLength = 8)]
    // [RegularExpression(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$", ErrorMessage = "Formato de telefone inválido. Ex: (11) 98765-4321")]
    [StringLength(9, MinimumLength = 8)]

    public string? PhoneNumber { get; set; }

  }
}