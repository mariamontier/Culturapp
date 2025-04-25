using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models.Responses
{
  public class OrganizerResponse
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CNPJ { get; set; }
  }
}
