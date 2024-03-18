using AutoMapper;
using SignalR_DtoLayer.ContactDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, GetAllContactResponseDto>().ReverseMap();
        CreateMap<Contact, GetContactResponseDto>().ReverseMap();
        CreateMap<Contact, CreateContactRequestDto>().ReverseMap();
        CreateMap<Contact, CreatedContactResponseDto>().ReverseMap();
        CreateMap<Contact, UpdateContactRequestDto>().ReverseMap();
        CreateMap<Contact, UpdatedContactResponseDto>().ReverseMap();
    }
}
