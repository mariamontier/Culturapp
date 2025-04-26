
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("Telephones")]
  public class Phone
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? AreaCode { get; set; }  // Changed "DDD" to "AreaCode" for clarity
    public string? PhoneNumber { get; set; }
    public Enterprise? Enterprise { get; set; }
    public Event? Event { get; set; }
  }
}

