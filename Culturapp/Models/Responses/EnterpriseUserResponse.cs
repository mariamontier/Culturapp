
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class EnterpriseUserResponse
  {
    public string? UserName { get; set; }
    public string? CNPJ { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<Event?>? Events { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<Phone?>? Phones { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
  }
}
