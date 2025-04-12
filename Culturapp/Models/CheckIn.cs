// namespace Culturapp.Models;

// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// [Table("CheckIns")]
// public class CheckIn
// {
//     [Key]
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     public int Id { get; set; }

//     [ForeignKey("CustomerId")]
//     public Customer Customer { get; set; }

//     [ForeignKey("EventId")]
//     public Event Event { get; set; }
//     public DateTime DateTime { get; set; }
// }