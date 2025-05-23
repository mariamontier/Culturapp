using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class ClientUserResponse
  {
    public int? Id { get; set; } // Se for útil no frontend
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? CPF { get; set; }

    public PhoneResponse? Phone { get; set; }
    public AddressResponse? Address { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<EventResponse?>? Events { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<CheckingResponse?>? Checks { get; set; }
  }
}
