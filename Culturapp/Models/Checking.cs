using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models;
[Table("Checks")]
public class Checking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? CheckString { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? EventId { get; set; }
    public Event? Event { get; set; }
    public DateTime? DateTime { get; set; }
}