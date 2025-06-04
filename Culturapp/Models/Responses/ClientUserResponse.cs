using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class ClientUserResponse
  {
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? CPF { get; set; }

    public PhoneResponse? PhoneResponse { get; set; }
    public AddressResponse? AddressResponse { get; set; }


    public ICollection<EventResponse?>? EventResponse { get; set; }


    public ICollection<CheckingResponse?>? CheckingResponse { get; set; }
  }
}
