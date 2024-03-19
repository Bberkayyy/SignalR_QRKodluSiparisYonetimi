using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.AboutDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutService _aboutService;
    private readonly IMapper _mapper;

    public AboutsController(IAboutService aboutService, IMapper mapper)
    {
        _aboutService = aboutService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllAboutResponseDto> values = _mapper.Map<IList<GetAllAboutResponseDto>>(_aboutService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateAboutRequestDto createAboutRequestDto)
    {
        About mappedAbout = _mapper.Map<About>(createAboutRequestDto);
        About value = _aboutService.TAdd(mappedAbout);
        CreatedAboutResponseDto createdAbout = _mapper.Map<CreatedAboutResponseDto>(value);
        return Created("", createdAbout);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        About value = _aboutService.TGetByFilter(x => x.Id == id);
        _aboutService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateAboutRequestDto updateAboutRequestDto)
    {
        About mappedAbout = _mapper.Map<About>(updateAboutRequestDto);
        About value = _aboutService.TUpdate(mappedAbout);
        UpdatedAboutResponseDto updatedAbout = _mapper.Map<UpdatedAboutResponseDto>(value);
        return Ok(updatedAbout);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        About value = _aboutService.TGetByFilter(x => x.Id == id);
        GetAboutResponseDto getAbout = _mapper.Map<GetAboutResponseDto>(value);
        return Ok(getAbout);
    }
}
