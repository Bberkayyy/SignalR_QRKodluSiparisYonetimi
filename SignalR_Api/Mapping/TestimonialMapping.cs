using AutoMapper;
using SignalR_DtoLayer.TestimonialDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class TestimonialMapping : Profile
{
    public TestimonialMapping()
    {
        CreateMap<Testimonial, GetAllTestimonialResponseDto>().ReverseMap();
        CreateMap<Testimonial, GetTestimonialResponseDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialRequestDto>().ReverseMap();
        CreateMap<Testimonial, CreatedTestimonialResponseDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialRequestDto>().ReverseMap();
        CreateMap<Testimonial, UpdatedTestimonialResponseDto>().ReverseMap();
    }
}
