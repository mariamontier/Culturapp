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
    public AddressResponse? AddressResponse { get; set; }

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
    public StatusResponse? StatusResponse { get; set; }

    // Check-in
    public int? CheckingId { get; set; }
    public CheckingResponse? Checking { get; set; }

    // FAQ
    public int? FAQId { get; set; }
    public FaqResponse? FaqResponse { get; set; }

    // Empresa organizadora
    public int? EnterpriseId { get; set; }
    public EnterpriseUserResponse? EnterpriseUserResponse { get; set; }

    // Categoria
    public int? CategoryId { get; set; }
    public CategoryResponse? CategoryResponse { get; set; }

    // Telefones
    public List<PhoneResponse>? PhoneResponses { get; set; }

    // Clientes
    public List<ClientUserResponse>? ClientUserResponses { get; set; }
  }
}
