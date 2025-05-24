using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class EnterpriseUserResponse
  {
    public int? Id { get; set; }
    public string? CNPJ { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public int? FAQId { get; set; }

    public ICollection<Phone?>? Phones { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
  }
}
