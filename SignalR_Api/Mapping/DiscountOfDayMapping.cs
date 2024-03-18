using AutoMapper;
using SignalR_DtoLayer.DiscountOfDayDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class DiscountOfDayMapping : Profile
{
    public DiscountOfDayMapping()
    {
        CreateMap<DiscountOfDay, GetAllDiscountOfDayResponseDto>().ReverseMap();
        CreateMap<DiscountOfDay, GetDiscountOfDayResponseDto>().ReverseMap();
        CreateMap<DiscountOfDay, CreateDiscountOfDayRequestDto>().ReverseMap();
        CreateMap<DiscountOfDay, CreatedDiscountOfDayResponseDto>().ReverseMap();
        CreateMap<DiscountOfDay, UpdateDiscountOfDayRequestDto>().ReverseMap();
        CreateMap<DiscountOfDay, UpdatedDiscountOfDayResponseDto>().ReverseMap();
    }
}
