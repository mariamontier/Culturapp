using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culturapp.Models.Responses
{
  public class EnterpriseResponse
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }  // Changed "EnterpriseId" to "Id" for consistency with other models
    public string? Cnpj { get; set; }  // Changed "Cnpj" to "TaxId" for better clarity
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? FAQId { get; set; }  // Changed "FaqId" to "FAQId" for consistency with other models
  }
}