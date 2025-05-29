

namespace Culturapp.Models.Requests;

public class CheckingRequest
{
  public DateTime? CheckInDate { get; set; }
  public Event? Event { get; set; }
  public ICollection<ClientUser?>? ClientUsers { get; set; }
}