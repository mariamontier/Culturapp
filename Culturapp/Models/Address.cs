using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models;
[Table("Addresses")]
public class Address
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Street { get; set; }
  public string? AddressNumber { get; set; }
  public string? Neighborhood { get; set; }
  public string? Complement { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? ZipCode { get; set; }
  public Event? Event { get; set; }
  public EnterpriseUser? EnterpriseUser { get; set; }

}
