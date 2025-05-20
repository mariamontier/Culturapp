namespace Culturapp.Models.Responses
{
  public class StatusResponse
  {
    public string? StatusName { get; set; } // Ativo, cancelado, etc.
    public ICollection<Event?>? Events { get; set; } // Eventos que estão com esse status
  }
}