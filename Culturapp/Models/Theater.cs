// namespace Culturapp.Models;

// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// [Table("Theaters")]
// public class Theater
// {
//     [Key]
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     public int Id { get; set; }
//     public string Name { get; set; }

//     [ForeignKey("AddressId")]
//     public Address Address { get; set; }
//     public string Phone { get; set; }
//     public int Capacity { get; set; }
// }