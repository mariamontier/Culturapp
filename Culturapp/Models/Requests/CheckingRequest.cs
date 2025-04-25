using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class CheckingRequest
  {
    public int CustomerId { get; set; }
    public int EventId { get; set; }
    public DateTime DateTime { get; set; }
  }
}
