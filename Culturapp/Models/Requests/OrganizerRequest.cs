using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Requests
{
  public class OrganizerRequest
  {
    public int UserId { get; set; }
    public string CNPJ { get; set; }
  }
}
