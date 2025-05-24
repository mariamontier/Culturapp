using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class FaqResponse
  {
    public int? Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EventResponse? EventResponse { get; set; }
  }
}