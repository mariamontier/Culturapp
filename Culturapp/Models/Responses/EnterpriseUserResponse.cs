
using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class EnterpriseUserResponse
  {
    public string? UserName { get; set; }
    public string? CNPJ { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public ICollection<Event?>? Events { get; set; }
    public ICollection<Phone?>? Phones { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
  }
}
