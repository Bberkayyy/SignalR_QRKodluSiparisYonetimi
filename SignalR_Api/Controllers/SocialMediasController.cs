using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.SocialMediaDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    private readonly ISocialMediaService _socialMediaService;
    private readonly IMapper _mapper;

    public SocialMediasController(ISocialMediaService SocialMediaService, IMapper mapper)
    {
        _socialMediaService = SocialMediaService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllSocialMediaResponseDto> values = _mapper.Map<IList<GetAllSocialMediaResponseDto>>(_socialMediaService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateSocialMediaRequestDto createSocialMediaRequestDto)
    {
        SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(createSocialMediaRequestDto);
        SocialMedia value = _socialMediaService.TAdd(mappedSocialMedia);
        CreatedSocialMediaResponseDto createdSocialMedia = _mapper.Map<CreatedSocialMediaResponseDto>(value);
        return Created("", createdSocialMedia);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        SocialMedia value = _socialMediaService.TGetByFilter(x => x.Id == id);
        _socialMediaService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateSocialMediaRequestDto updateSocialMediaRequestDto)
    {
        SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(updateSocialMediaRequestDto);
        SocialMedia value = _socialMediaService.TUpdate(mappedSocialMedia);
        UpdatedSocialMediaResponseDto updatedSocialMedia = _mapper.Map<UpdatedSocialMediaResponseDto>(value);
        return Ok(updatedSocialMedia);
    }
    [HttpGet("getbyid")]
    public IActionResult Get(int id)
    {
        SocialMedia value = _socialMediaService.TGetByFilter(x => x.Id == id);
        GetSocialMediaResponseDto getSocialMedia = _mapper.Map<GetSocialMediaResponseDto>(value);
        return Ok(getSocialMedia);
    }
}
