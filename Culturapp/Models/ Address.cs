
namespace Culturapp.Models
{
  public class Address
  {
    [Key]
    public int Id { get; set; }
    public string? PublicPlace { get; set; }
    public int Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? Complement { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
 
  }
}