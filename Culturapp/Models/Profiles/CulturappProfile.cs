using AutoMapper;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

namespace Culturapp.Models.Profiles
{
  public class CulturappProfile : Profile
  {
    public CulturappProfile()
    {
      // Address
      CreateMap<Address, AddressResponse>().ReverseMap();
      CreateMap<Address, AddressRequest>().ReverseMap();

      // Category
      CreateMap<Category, CategoryResponse>().ReverseMap();
      CreateMap<Category, CategoryRequest>().ReverseMap();

      // CheckIn
      CreateMap<Checking, CheckingResponse>().ReverseMap();

      // Event
      CreateMap<Event, EventResponse>().ReverseMap();
      CreateMap<Event, EventRequest>().ReverseMap();


      // Faq
      CreateMap<FAQ, FaqResponse>().ReverseMap();
      CreateMap<FAQ, FaqRequest>().ReverseMap();

    }
  }
}