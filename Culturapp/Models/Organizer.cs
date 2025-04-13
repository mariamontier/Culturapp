
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("Organizers")]
  public class Organizer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //  [ForeignKey("UserId")]
    //     public User User { get; set; }
    public string? Cnpj { get; set; }
  }
}
