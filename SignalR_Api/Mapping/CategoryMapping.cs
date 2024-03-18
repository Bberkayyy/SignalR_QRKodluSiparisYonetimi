using AutoMapper;
using SignalR_DtoLayer.CategoryDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, GetAllCategoryResponseDto>().ReverseMap();
        CreateMap<Category, GetCategoryResponseDto>().ReverseMap();
        CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponseDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponseDto>().ReverseMap();
    }
}
