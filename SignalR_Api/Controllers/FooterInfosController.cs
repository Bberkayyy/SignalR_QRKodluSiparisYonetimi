using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.FooterInfoDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FooterInfosController : ControllerBase
{
    private readonly IFooterInfoService _footerInfoService;
    private readonly IMapper _mapper;

    public FooterInfosController(IFooterInfoService FooterInfoService, IMapper mapper)
    {
        _footerInfoService = FooterInfoService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllFooterInfoResponseDto> values = _mapper.Map<IList<GetAllFooterInfoResponseDto>>(_footerInfoService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateFooterInfoRequestDto createFooterInfoRequestDto)
    {
        FooterInfo mappedFooterInfo = _mapper.Map<FooterInfo>(createFooterInfoRequestDto);
        FooterInfo value = _footerInfoService.TAdd(mappedFooterInfo);
        CreatedFooterInfoResponseDto createdFooterInfo = _mapper.Map<CreatedFooterInfoResponseDto>(value);
        return Created("", createdFooterInfo);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        FooterInfo value = _footerInfoService.TGetByFilter(x => x.Id == id);
        _footerInfoService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateFooterInfoRequestDto updateFooterInfoRequestDto)
    {
        FooterInfo mappedFooterInfo = _mapper.Map<FooterInfo>(updateFooterInfoRequestDto);
        FooterInfo value = _footerInfoService.TUpdate(mappedFooterInfo);
        UpdatedFooterInfoResponseDto updatedFooterInfo = _mapper.Map<UpdatedFooterInfoResponseDto>(value);
        return Ok(updatedFooterInfo);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        FooterInfo value = _footerInfoService.TGetByFilter(x => x.Id == id);
        GetFooterInfoResponseDto getFooterInfo = _mapper.Map<GetFooterInfoResponseDto>(value);
        return Ok(getFooterInfo);
    }
}
