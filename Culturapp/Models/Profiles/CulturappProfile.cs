using AutoMapper;
using Culturapp.Models;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

public class CulturappProfile : Profile
{
  public CulturappProfile()
  {
    // Address
    CreateMap<Address, AddressResponse>();
    CreateMap<Address, AddressRequest>();

    // Category
    CreateMap<Category, CategoryResponse>();
    CreateMap<Category, CategoryRequest>();

    // CheckIn
    CreateMap<Checking, CheckingResponse>();
    CreateMap<Checking, CheckingRequest>();

    // Customer
    CreateMap<Customer, CustomerResponse>();
    CreateMap<Customer, CustomerRequest>();

    // Event
    CreateMap<Event, EventResponse>();
    CreateMap<Event, EventRequest>();

    // EventLocation
    CreateMap<EventLocation, EventLocationResponse>();
    CreateMap<EventLocation, EventLocationRequest>();

    // Faq
    CreateMap<Faq, FaqResponse>();
    CreateMap<Faq, FaqRequest>();

    // User
    CreateMap<User, UserResponse>();
    CreateMap<User, UserRequest>();
  }
}