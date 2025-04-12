using AutoMapper;
using Culturapp.Models;
using Culturapp.Models.Requests;

public class CulturappProfile : Profile
{
  public CulturappProfile()
  {
    // Configurações de mapeamento
    CreateMap<Event, EventRequest>().ReverseMap();
  }
}