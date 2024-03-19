using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.TestimonialDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController : ControllerBase
{
    private readonly ITestimonialService _testimonialService;
    private readonly IMapper _mapper;

    public TestimonialsController(ITestimonialService TestimonialService, IMapper mapper)
    {
        _testimonialService = TestimonialService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllTestimonialResponseDto> values = _mapper.Map<IList<GetAllTestimonialResponseDto>>(_testimonialService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateTestimonialRequestDto createTestimonialRequestDto)
    {
        Testimonial mappedTestimonial = _mapper.Map<Testimonial>(createTestimonialRequestDto);
        Testimonial value = _testimonialService.TAdd(mappedTestimonial);
        CreatedTestimonialResponseDto createdTestimonial = _mapper.Map<CreatedTestimonialResponseDto>(value);
        return Created("", createdTestimonial);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Testimonial value = _testimonialService.TGetByFilter(x => x.Id == id);
        _testimonialService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateTestimonialRequestDto updateTestimonialRequestDto)
    {
        Testimonial mappedTestimonial = _mapper.Map<Testimonial>(updateTestimonialRequestDto);
        Testimonial value = _testimonialService.TUpdate(mappedTestimonial);
        UpdatedTestimonialResponseDto updatedTestimonial = _mapper.Map<UpdatedTestimonialResponseDto>(value);
        return Ok(updatedTestimonial);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Testimonial value = _testimonialService.TGetByFilter(x => x.Id == id);
        GetTestimonialResponseDto getTestimonial = _mapper.Map<GetTestimonialResponseDto>(value);
        return Ok(getTestimonial);
    }
}
