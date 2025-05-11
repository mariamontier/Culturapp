using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class CategoryResponse
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? EventId { get; set; }
  }
}
