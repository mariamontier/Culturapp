using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class TheaterResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int AddressId { get; set; }
    public string Phone { get; set; }
    public int Capacity { get; set; }
  }
}
