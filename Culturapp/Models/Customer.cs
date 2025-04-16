using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models;
[Table("Customers")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public User? User { get; set; }
    public string? CPF { get; set; }
    public Address? Address { get; set; }
    public List<Checking>? Checks { get; set; }
}
