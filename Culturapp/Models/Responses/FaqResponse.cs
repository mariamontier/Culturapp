using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class FaqResponse
  {
    public int? Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("EventsJson")]
    public EventResponse? EventResponse { get; set; }
  }
}