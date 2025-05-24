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

    public ICollection<PhoneResponse?>? PhoneResponse { get; set; }
    public int? AddressId { get; set; }
    public AddressResponse? AddressResponse { get; set; }
  }
}
