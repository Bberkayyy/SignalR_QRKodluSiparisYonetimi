using AutoMapper;
using SignalR_DtoLayer.OrderDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order, GetAllOrderResponseDto>().ReverseMap();
        CreateMap<Order, GetOrderResponseDto>().ReverseMap();
        CreateMap<Order, CreateOrderRequestDto>().ReverseMap();
        CreateMap<Order, CreatedOrderResponseDto>().ReverseMap();
        CreateMap<Order, UpdateOrderRequestDto>().ReverseMap();
        CreateMap<Order, UpdatedOrderResponseDto>().ReverseMap();
    }
}
