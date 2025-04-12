using System;
using System.ComponentModel.DataAnnotations;

namespace Culturapp.Models
{
  public class Event
  {
    [Key]
    public int Id { get; set; }
    public string? Cnpj { get; set; }
  }
}