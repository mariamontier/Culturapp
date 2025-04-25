using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class EventLocationRequest
  {
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public int? Capacity { get; set; }
  }
}
