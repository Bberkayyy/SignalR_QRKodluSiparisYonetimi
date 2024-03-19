using AutoMapper;
using SignalR_DtoLayer.ProductDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, GetAllProductResponseDto>().ReverseMap();
        CreateMap<Product, GetProductResponseDto>().ReverseMap();
        CreateMap<Product, CreateProductRequestDto>().ReverseMap();
        CreateMap<Product, CreatedProductResponseDto>().ReverseMap();
        CreateMap<Product, UpdateProductRequestDto>().ReverseMap();
        CreateMap<Product, UpdatedProductResponseDto>().ReverseMap();
        CreateMap<Product, GetAllProductWithCategoryResponseDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name)).ReverseMap();
        CreateMap<Product, GetProductWithCategoryResponseDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name)).ReverseMap();
    }
}
