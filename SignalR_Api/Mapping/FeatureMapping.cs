using AutoMapper;
using SignalR_DtoLayer.FeatureDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<Feature, GetAllFeatureResponseDto>().ReverseMap();
        CreateMap<Feature, GetFeatureResponseDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureRequestDto>().ReverseMap();
        CreateMap<Feature, CreatedFeatureResponseDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureRequestDto>().ReverseMap();
        CreateMap<Feature, UpdatedFeatureResponseDto>().ReverseMap();
    }
}
