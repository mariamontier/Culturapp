using System.Text.Json.Serialization;
using Culturapp.Models.Responses;

namespace Culturapp.Models.Responses;

public class StatusResponse
{
  public int? Id { get; set; }
  public string? StatusName { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public ICollection<EventResponse>? Events { get; set; }
}
