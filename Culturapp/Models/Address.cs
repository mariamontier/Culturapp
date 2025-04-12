namespace Culturapp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Addresses")]
public class Address
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Street { get; set; }
  public string? Number { get; set; }
  public string? Neighborhood { get; set; }
  public string? Complement { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? ZipCode { get; set; }
}
