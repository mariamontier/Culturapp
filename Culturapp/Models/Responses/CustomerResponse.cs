using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class CustomerResponse
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CPF { get; set; }
  }
}
