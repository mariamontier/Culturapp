
namespace Culturapp.Models
{
  public class Checking
  {
    [Key]
    public int Id { get; set; }
    public DateTime? InterestDate { get; set; }
    public DateTime? AttendanceDate { get; set; }
    public DateTime? CancellationDate { get; set; }
  }
}