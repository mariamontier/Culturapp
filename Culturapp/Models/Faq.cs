using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models
{
  [Table("Faqs")]
  public class FAQ
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public Event? Event { get; set; }
  }
}


// Esse Faq pode ser de evento ou so nosso de app, pois podemos reaproveitar o código para falar do app. 