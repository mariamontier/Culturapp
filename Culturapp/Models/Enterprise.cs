using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("Enterprises")]
  public class Enterprise
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CNPJ { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public ICollection<Event?>? Events { get; set; }
    public ICollection<Phone?>? Phones { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }

  }
}
