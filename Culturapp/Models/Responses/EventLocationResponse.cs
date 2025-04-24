using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class EventLocationResponse
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public int? Capacity { get; set; }
  }
}
