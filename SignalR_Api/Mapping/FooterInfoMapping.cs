using AutoMapper;
using SignalR_DtoLayer.FooterInfoDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class FooterInfoMapping : Profile
{
    public FooterInfoMapping()
    {
        CreateMap<FooterInfo, GetAllFooterInfoResponseDto>().ReverseMap();
        CreateMap<FooterInfo, GetFooterInfoResponseDto>().ReverseMap();
        CreateMap<FooterInfo, CreateFooterInfoRequestDto>().ReverseMap();
        CreateMap<FooterInfo, CreatedFooterInfoResponseDto>().ReverseMap();
        CreateMap<FooterInfo, UpdateFooterInfoRequestDto>().ReverseMap();
        CreateMap<FooterInfo, UpdatedFooterInfoResponseDto>().ReverseMap();
    }
}
