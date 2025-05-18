namespace Culturapp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categories")]
public class Category
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public Guid Id { get; set; } = Guid.NewGuid();
  public string? Name { get; set; }
  public string? Description { get; set; }
  public ICollection<Event?>? Events { get; set; }
}
