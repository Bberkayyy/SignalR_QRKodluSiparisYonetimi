using AutoMapper;
using SignalR_DtoLayer.OrderDetailDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class OrderDetailMapping : Profile
{
    public OrderDetailMapping()
    {
        CreateMap<OrderDetail, GetAllOrderDetailResponseDto>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailResponseDto>().ReverseMap();
        CreateMap<OrderDetail, CreateOrderDetailRequestDto>().ReverseMap();
        CreateMap<OrderDetail, CreatedOrderDetailResponseDto>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailRequestDto>().ReverseMap();
        CreateMap<OrderDetail, UpdatedOrderDetailResponseDto>().ReverseMap();
        CreateMap<OrderDetail, GetAllOrderDetailWithRelationshipsResponseDto>().ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name)).ForMember(x => x.OrderTableName, opt => opt.MapFrom(x => x.Order.RestaurantTable.Name)).ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailWithRelationshipsResponseDto>().ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name)).ForMember(x => x.OrderTableName, opt => opt.MapFrom(x => x.Order.RestaurantTable.Name)).ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailWithRelationshipsByOrderIdResponseDto>().ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name)).ForMember(x => x.OrderTableName, opt => opt.MapFrom(x => x.Order.RestaurantTable.Name)).ReverseMap();
    }
}
