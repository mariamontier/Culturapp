using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class CustomerRequest
  {
    public int UserId { get; set; }
    public string CPF { get; set; }
  }
}
