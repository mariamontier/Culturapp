using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class CheckInRequest
  {
    public int CustomerId { get; set; }
    public int EventId { get; set; }
    public DateTime DateTime { get; set; }
  }
}
