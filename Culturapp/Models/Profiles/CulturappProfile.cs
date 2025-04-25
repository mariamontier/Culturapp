using AutoMapper;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

namespace Culturapp.Models.Profiles;

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
    CreateMap<Checking, CheckingRequest>().ReverseMap();

    // Customer
    CreateMap<Customer, CustomerResponse>().ReverseMap();
    CreateMap<Customer, CustomerRequest>().ReverseMap();

    // Event
    CreateMap<Event, EventResponse>().ReverseMap();
    CreateMap<Event, EventRequest>().ReverseMap();

    // EventLocation
    CreateMap<EventLocation, EventLocationResponse>().ReverseMap();
    CreateMap<EventLocation, EventLocationRequest>().ReverseMap();

    // Faq
    CreateMap<Faq, FaqResponse>().ReverseMap();
    CreateMap<Faq, FaqRequest>().ReverseMap();

    // User
    CreateMap<User, UserResponse>().ReverseMap();
    CreateMap<User, UserRequest>().ReverseMap();
  }
}