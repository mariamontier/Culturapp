using AutoMapper;
using Culturapp.Models.Requests;
using Culturapp.Models.Responses;

namespace Culturapp.Models.Profiles
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
    CreateMap<CheckIn, CheckInResponse>();
    CreateMap<CheckIn, CheckInRequest>();

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

    // Organizer
    CreateMap<Organizer, OrganizerResponse>();
    CreateMap<Organizer, OrganizerRequest>();

    // Theater
    CreateMap<Theater, TheaterResponse>();
    CreateMap<Theater, TheaterRequest>();

    // User
    CreateMap<User, UserResponse>();
    CreateMap<User, UserRequest>();
}
}
