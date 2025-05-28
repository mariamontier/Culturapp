namespace Culturapp.Models.Requests
{
  public class FaqRequest
  {
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public int? EventId { get; set; }
  }
}
