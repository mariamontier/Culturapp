using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("Companies")]
  public class Company
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public User? User { get; set; }
    public string? Cnpj { get; set; }
    public Address? Address { get; set; }

  }
}
