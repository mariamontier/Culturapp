using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class CategoryResponse
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    // Retorna os eventos associados à categoria, se existirem
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<EventResponse>? Events { get; set; }
  }
}
