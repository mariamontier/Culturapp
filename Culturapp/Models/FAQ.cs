// namespace Culturapp.Models;

// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// [Table("FAQs")]
// public class FAQ
// {
//     [Key]
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     public int Id { get; set; }

//     [ForeignKey("EventId")]
//     public Event Event { get; set; }
//     public string Question { get; set; }
//     public string Answer { get; set; }
// }