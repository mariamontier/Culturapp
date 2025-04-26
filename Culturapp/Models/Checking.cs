using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models;
[Table("Checkings")]
public class Checking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime? CheckInDate { get; set; }
    public Event? Event { get; set; }
    public ICollection<User?>? User { get; set; }
}