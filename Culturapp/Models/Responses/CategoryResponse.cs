using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class CategoryResponse
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("EventsJson")]
    public List<EventResponse>? Events { get; set; }
  }
}
