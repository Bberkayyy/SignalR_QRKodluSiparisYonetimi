using AutoMapper;
using SignalR_DtoLayer.AboutDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class AboutMapping : Profile
{
    public AboutMapping()
    {
        CreateMap<About, GetAllAboutResponseDto>().ReverseMap();
        CreateMap<About, GetAboutResponseDto>().ReverseMap();
        CreateMap<About, CreateAboutRequestDto>().ReverseMap();
        CreateMap<About, CreatedAboutResponseDto>().ReverseMap();
        CreateMap<About, UpdateAboutRequestDto>().ReverseMap();
        CreateMap<About, UpdatedAboutResponseDto>().ReverseMap();
    }
}
