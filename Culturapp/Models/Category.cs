namespace Culturapp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categories")]
public class Category
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int EventId { get; set; }
  public Event? Event { get; set; }
}
