namespace Culturapp.Models.Requests
{
  public class PhoneRequest
  {
    public string? CountryCode { get; set; }
    public string? AreaCode { get; set; }
    public string? PhoneNumber { get; set; }
  }
}