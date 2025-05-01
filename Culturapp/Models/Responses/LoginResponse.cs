namespace Culturapp.Models.Responses
{
  public class LoginResponse
  {
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? AccountType { get; set; }
    public DateTime? Expiration { get; set; }
  }
}