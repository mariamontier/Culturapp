using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class TheaterRequest
  {
    public string Name { get; set; }
    public int AddressId { get; set; }
    public string Phone { get; set; }
    public int Capacity { get; set; }
  }
}
