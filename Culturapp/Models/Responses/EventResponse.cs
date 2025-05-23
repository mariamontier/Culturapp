namespace Culturapp.Models.Responses
{
  public class EventResponse
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }

    // Local
    public int? LocationAddressId { get; set; }
    public string? LocationStreet { get; set; }

    // Capacidade e preço
    public int? Capacity { get; set; }
    public double? TicketPrice { get; set; }

    // Vendas
    public DateTime? SalesStartDate { get; set; }
    public DateTime? SalesEndDate { get; set; }

    // Outros dados
    public double? ScoreValue { get; set; }

    // Status
    public int? StatusId { get; set; }
    public string? StatusName { get; set; }

    // Check-in
    public int? CheckingId { get; set; }
    public CheckingResponse? Checking { get; set; }

    // FAQ
    public int? FAQId { get; set; }
    public string? FAQTitle { get; set; }

    // Empresa organizadora
    public int? EnterpriseId { get; set; }
    public string? EnterpriseName { get; set; }

    // Categoria
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }

    // Telefones
    public List<PhoneResponse>? Phones { get; set; }

    // Clientes
    public List<ClientUserResponse>? ClientUsers { get; set; }
  }
}
