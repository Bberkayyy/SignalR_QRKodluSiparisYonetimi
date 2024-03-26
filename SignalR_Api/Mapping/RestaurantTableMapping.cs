using AutoMapper;
using SignalR_DtoLayer.RestaurantTableDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class RestaurantTableMapping :Profile
{
    public RestaurantTableMapping()
    {
        CreateMap<RestaurantTable, GetAllRestaurantTableResponseDto>().ReverseMap();
        CreateMap<RestaurantTable, GetRestaurantTableResponseDto>().ReverseMap();
        CreateMap<RestaurantTable, CreateRestaurantTableRequestDto>().ReverseMap();
        CreateMap<RestaurantTable, CreatedRestaurantTableResponseDto>().ReverseMap();
        CreateMap<RestaurantTable, UpdateRestaurantTableRequestDto>().ReverseMap();
        CreateMap<RestaurantTable, UpdatedRestaurantTableResponseDto>().ReverseMap();
    }
}
