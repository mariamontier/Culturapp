using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class FaqResponse
  {
    public string Question { get; set; }
    public string Answer { get; set; }
    public int? EventId { get; set; }
  }
}
