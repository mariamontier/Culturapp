using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class CategoryResponse
  {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<EventResponse>? Events { get; set; } // para retornar todos os eventos associados a ela 
  }
}
