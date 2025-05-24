namespace Culturapp.Models.Responses
{
  public class CheckingResponse
  {
    public int? Id { get; set; } // Opcional: útil se você precisar manipular o check-in
    public DateTime? CheckInDate { get; set; }
    public int? ClientUserId { get; set; } // Nome mais claro
    public int? EventId { get; set; } // Opcional: se for útil no retorno
  }
}
