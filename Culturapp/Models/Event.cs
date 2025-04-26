using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models;
[Table("Events")]
public class Event
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Name { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
  public string? Description { get; set; }
  public Address? LocationAddress { get; set; }
  public int? Capacity { get; set; } // Limite de usuários, baseado na lista de usuários.
  public double? TicketPrice { get; set; }
  public DateTime? SalesStartDate { get; set; }
  public DateTime? SalesEndDate { get; set; }
  public double? ScoreValue { get; set; } // Score will be based on the Ticket Price
  public Status? Status { get; set; } // baseado nas datas e/ou na capacidade, ou cancelado pelo admin
  public Checking? Checking { get; set; } // apos a data de inicio e bloqueado depois da data de fim mais um dia.
  public FAQ? FAQ { get; set; }
  public Enterprise? Enterprise { get; set; } // Empresa que está organizando o evento
  public Category? Category { get; set; } // Categoria do evento, como teatro, show, etc.
  public ICollection<Phone?>? Phones { get; set; }
  public ICollection<User?>? Users { get; set; }
}