using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("EventLocations")]
  public class EventLocation
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }

    // [ForeignKey("AddressId")]
    // public Address Address { get; set; }
    public string? Telephone { get; set; }
    public int? Capacity { get; set; }
  }
}