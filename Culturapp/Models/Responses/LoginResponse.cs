namespace Culturapp.Models.Responses
{
  public class LoginResponse
  {
    public string? Token { get; set; }
    public string? Identifier { get; set; }
    public string? AccountType { get; set; }
  }
}