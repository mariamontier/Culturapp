using AutoMapper;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

namespace Culturapp.Models.Profiles
{
  public class CulturappProfile : Profile
  {
    public CulturappProfile()
    {

      // ClientUser
      CreateMap<ClientUser, ClientUserRequest>().ReverseMap();
      CreateMap<ClientUser, ClientUserResponse>().ReverseMap();

      // EnterpriseUser
      CreateMap<EnterpriseUser, EnterpriseUserRequest>().ReverseMap();
      CreateMap<EnterpriseUser, EnterpriseUserResponse>().ReverseMap();

      // Register
      CreateMap<ApplicationUser, RegisterRequest>().ReverseMap();

      // Login
      CreateMap<Login, LoginRequest>().ReverseMap();

      // Address
      CreateMap<Address, AddressResponse>().ReverseMap();
      CreateMap<Address, AddressRequest>().ReverseMap();

      // Category
      CreateMap<Category, CategoryResponse>().ReverseMap();
      CreateMap<Category, CategoryRequest>().ReverseMap();

      // CheckIn
      CreateMap<Checking, CheckingResponse>().ReverseMap();

      // Event
      CreateMap<Event, EventRequest>().ReverseMap();
      CreateMap<Event, EventResponse>()
    .ForMember(dest => dest.EnterpriseName, opt => opt.MapFrom(src => src.EnterpriseUser.FullName))
    .ForMember(dest => dest.LocationAddressId, opt => opt.MapFrom(src => src.LocationAddress.Street))
    .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones))
    .ForMember(dest => dest.ClientUsers, opt => opt.MapFrom(src => src.ClientUsers));


      // Faq
      CreateMap<FAQ, FaqResponse>().ReverseMap();
      CreateMap<FAQ, FaqRequest>().ReverseMap();

      // Status
      CreateMap<Status, StatusRequest>().ReverseMap();
      CreateMap<Status, StatusResponse>().ReverseMap();

    }
  }
}