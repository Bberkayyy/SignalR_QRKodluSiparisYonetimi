using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.DiscountOfDayDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountOfDaysController : ControllerBase
{
    private readonly IDiscountOfDayService _discountOfDayService;
    private readonly IMapper _mapper;

    public DiscountOfDaysController(IDiscountOfDayService DiscountOfDayService, IMapper mapper)
    {
        _discountOfDayService = DiscountOfDayService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllDiscountOfDayResponseDto> values = _mapper.Map<IList<GetAllDiscountOfDayResponseDto>>(_discountOfDayService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateDiscountOfDayRequestDto createDiscountOfDayRequestDto)
    {
        DiscountOfDay mappedDiscountOfDay = _mapper.Map<DiscountOfDay>(createDiscountOfDayRequestDto);
        DiscountOfDay value = _discountOfDayService.TAdd(mappedDiscountOfDay);
        CreatedDiscountOfDayResponseDto createdDiscountOfDay = _mapper.Map<CreatedDiscountOfDayResponseDto>(value);
        return Created("", createdDiscountOfDay);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        DiscountOfDay value = _discountOfDayService.TGetByFilter(x => x.Id == id);
        _discountOfDayService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateDiscountOfDayRequestDto updateDiscountOfDayRequestDto)
    {
        DiscountOfDay mappedDiscountOfDay = _mapper.Map<DiscountOfDay>(updateDiscountOfDayRequestDto);
        DiscountOfDay value = _discountOfDayService.TUpdate(mappedDiscountOfDay);
        UpdatedDiscountOfDayResponseDto updatedDiscountOfDay = _mapper.Map<UpdatedDiscountOfDayResponseDto>(value);
        return Ok(updatedDiscountOfDay);
    }
    [HttpGet("getbyid")]
    public IActionResult Get(int id)
    {
        DiscountOfDay value = _discountOfDayService.TGetByFilter(x => x.Id == id);
        GetDiscountOfDayResponseDto getDiscountOfDay = _mapper.Map<GetDiscountOfDayResponseDto>(value);
        return Ok(getDiscountOfDay);
    }
}
