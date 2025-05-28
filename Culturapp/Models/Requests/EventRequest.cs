namespace Culturapp.Models.Requests
{
  public class EventRequest
  {
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public int? LocationAddressId { get; set; }
    public int? Capacity { get; set; } // Limite de usuários, baseado na lista de usuários.
    public double? TicketPrice { get; set; }
    public DateTime? SalesStartDate { get; set; }
    public DateTime? SalesEndDate { get; set; }
    public int? StatusId { get; set; } // baseado nas datas e/ou na capacidade, ou cancelado pelo admin
    public int? CheckingInt { get; set; } // apos a data de inicio e bloqueado depois da data de fim mais um dia.
    public int? FAQInt { get; set; }
    public int? EnterpriseUserId { get; set; } // Empresa que está organizando o evento
    //public Guid? CategoryId { get; set; } // Categoria do evento, como teatro, show, etc.
    public int? CategoryId { get; set; }
    public ICollection<int?>? PhonesId { get; set; }
    public ICollection<int?>? ClientUsersId { get; set; }
  }
}