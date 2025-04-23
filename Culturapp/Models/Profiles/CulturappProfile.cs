using AutoMapper;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

public class CulturappProfile : Profile
{
  public CulturappProfile()
  {
    // Configurações de mapeamento
    CreateMap<Event, EventRequest>().ReverseMap();
    CreateMap<Event, EventResponse>().ReverseMap();
  }
}