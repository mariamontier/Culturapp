
namespace Culturapp.Models;

public class Status
{
  public int Id { get; set; }
  public string? StatusName { get; set; } // Ativo, cancelado, etc.
  public ICollection<Event>? Events { get; set; } // Eventos que estão com esse status
}

