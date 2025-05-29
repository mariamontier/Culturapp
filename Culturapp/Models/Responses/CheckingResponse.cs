namespace Culturapp.Models.Responses
{
  public class CheckingResponse
  {
    public int? Id { get; set; }
    public DateTime? CheckInDate { get; set; }
    public EventResponse? EventResponse { get; set; }
    public ICollection<ClientUserResponse?>? ClientUserResponses { get; set; }
  }
}
