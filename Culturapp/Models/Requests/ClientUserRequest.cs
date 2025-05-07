namespace Culturapp.Models.Requests
{
  public class ClientUserRequest
  {
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public int? PhoneId { get; set; }
    public string? CPF { get; set; }
    public int? AddressId { get; set; }
  }
}
