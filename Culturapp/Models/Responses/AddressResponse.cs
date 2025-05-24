namespace Culturapp.Models.Responses
{
  public class AddressResponse
  {
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? Complement { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }

    public int? EnterpriseUserId { get; set; } // Renomeado por clareza
    public int? EventId { get; set; }
  }
}
