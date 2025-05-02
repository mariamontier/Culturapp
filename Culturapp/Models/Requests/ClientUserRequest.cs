namespace Culturapp.Models.Requests
{
  public class ClientUserRequest
  {
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public Phone? Phone { get; set; }
    public string? CPF { get; set; }
    public Address? Address { get; set; }
    public ICollection<Event?>? Events { get; set; }
    public ICollection<Checking?>? Checks { get; set; }
  }
}
