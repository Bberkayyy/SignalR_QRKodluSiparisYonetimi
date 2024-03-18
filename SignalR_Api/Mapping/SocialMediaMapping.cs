using AutoMapper;
using SignalR_DtoLayer.SocialMediaDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class SocialMediaMapping : Profile
{
    public SocialMediaMapping()
    {
        CreateMap<SocialMedia, GetAllSocialMediaResponseDto>().ReverseMap();
        CreateMap<SocialMedia, GetSocialMediaResponseDto>().ReverseMap();
        CreateMap<SocialMedia, CreateSocialMediaRequestDto>().ReverseMap();
        CreateMap<SocialMedia, CreatedSocialMediaResponseDto>().ReverseMap();
        CreateMap<SocialMedia, UpdateSocialMediaRequestDto>().ReverseMap();
        CreateMap<SocialMedia, UpdatedSocialMediaResponseDto>().ReverseMap();
    }
}
