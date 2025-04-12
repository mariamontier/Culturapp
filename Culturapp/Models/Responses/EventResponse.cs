using System;
using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class EventResponse
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public double? ScoreValue { get; set; }
    public double? TicketPrice { get; set; }
    public int? Capacity { get; set; }
    public string? Status { get; set; }
    public string? Location { get; set; }
    public int? Price { get; set; }
  }
}