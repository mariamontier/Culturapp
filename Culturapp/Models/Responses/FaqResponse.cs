using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class FaqResponse
  {
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
  }
}
