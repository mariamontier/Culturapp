namespace Culturapp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Events")]
public class Event
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public DateTime? Date { get; set; }
  public double? ScoreValue { get; set; }
  public double? TicketPrice { get; set; }
  public int? Capacity { get; set; }
  public string? Status { get; set; }
  public string? Location { get; set; }
  public int? Price { get; set; }


  // [ForeignKey("TheaterId")]
  // public Theater Theater { get; set; }
  // [ForeignKey("OrganizerId")]
  // public Organizer Organizer { get; set; }

}