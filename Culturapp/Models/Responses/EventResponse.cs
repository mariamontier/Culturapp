namespace Culturapp.Models.Responses
{
  public class EventResponse
  {

    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int? Capacity { get; set; }
    public decimal? Price { get; set; }  // Changed type from int to decimal for better financial precision
    public double? ScoreValue { get; set; }
    public string? Status { get; set; }
    public decimal? TicketPrice { get; set; }  // Changed type from int to decimal
    public DateTime? EndDate { get; set; }
    public DateTime? SaleStartDate { get; set; }
    public DateTime? SaleEndDate { get; set; }
    public int? CheckingId { get; set; }
  }
}