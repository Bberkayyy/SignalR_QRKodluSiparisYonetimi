using AutoMapper;
using SignalR_DtoLayer.CartDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class CartMapping : Profile
{
    public CartMapping()
    {
        CreateMap<Cart, GetAllCartResponseDto>().ReverseMap();
        CreateMap<Cart, GetCartResponseDto>().ReverseMap();
        CreateMap<Cart, CreateCartRequestDto>().ReverseMap();
        CreateMap<Cart, CreatedCartResponseDto>().ReverseMap();
        CreateMap<Cart, UpdateCartRequestDto>().ReverseMap();
        CreateMap<Cart, UpdatedCartResponseDto>().ReverseMap();
        CreateMap<Cart, GetAllCartWithRelationshipsResponseDto>()
            .ForMember(x => x.RestaurantTableName, opt => opt.MapFrom(x => x.RestaurantTable.Name))
            .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name))
            .ForMember(x => x.ProductPrice, opt => opt.MapFrom(x => x.Product.Price))
            .ReverseMap();
        CreateMap<Cart, GetCartWithRelationshipsResponseDto>()
            .ForMember(x => x.RestaurantTableName, opt => opt.MapFrom(x => x.RestaurantTable.Name))
            .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name))
            .ForMember(x => x.ProductPrice, opt => opt.MapFrom(x => x.Product.Price)).ReverseMap();
    }
}
