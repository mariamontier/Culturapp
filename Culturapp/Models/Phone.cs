
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  public class Phone
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Number { get; set; }
    public string? Type { get; set; } // e.g., Mobile, Home, Work
  }
}