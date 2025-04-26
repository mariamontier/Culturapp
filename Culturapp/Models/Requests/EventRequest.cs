using System;
using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class EventRequest
  {
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
    public float Price { get; set; }
    public double ScoreValue { get; set; }
    public string Status { get; set; }
    public float TicketPrice { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime SaleStartDate { get; set; }
    public DateTime SaleEndDate { get; set; }
    public int CheckingId { get; set; }
  }
}