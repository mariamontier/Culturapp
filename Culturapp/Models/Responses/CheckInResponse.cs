using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class CheckInResponse
  {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EventId { get; set; }
    public DateTime DateTime { get; set; }
  }
}
