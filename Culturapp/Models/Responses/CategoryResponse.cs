using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Culturapp.Models.Responses
{
  public class CategoryResponse
  {
    //public Guid Id { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<EventResponse>? Events { get; set; } // para retornar todos os eventos associados a ela 
  }
}
