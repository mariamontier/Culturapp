namespace Culturapp.Models
{
  public class Login
  {
    public string Password { get; set; } = null!;
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }
  }
}
