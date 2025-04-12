namespace Culturapp.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
  }
}
=======
// namespace Culturapp.Models;

// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// [Table("Categories")]
// public class Category
// {
//   [Key]
//   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//   public int Id { get; set; }
//   public string Name { get; set; }
//   public string Description { get; set; }
// }
