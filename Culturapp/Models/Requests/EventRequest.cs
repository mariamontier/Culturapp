using System;
using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class EventRequest
  {
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int? Capacity { get; set; }
    public decimal? Price { get; set; }
  }
}