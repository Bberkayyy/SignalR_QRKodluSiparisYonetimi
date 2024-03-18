using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.FeatureDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;
    private readonly IMapper _mapper;

    public FeaturesController(IFeatureService FeatureService, IMapper mapper)
    {
        _featureService = FeatureService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllFeatureResponseDto> values = _mapper.Map<IList<GetAllFeatureResponseDto>>(_featureService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateFeatureRequestDto createFeatureRequestDto)
    {
        Feature mappedFeature = _mapper.Map<Feature>(createFeatureRequestDto);
        Feature value = _featureService.TAdd(mappedFeature);
        CreatedFeatureResponseDto createdFeature = _mapper.Map<CreatedFeatureResponseDto>(value);
        return Created("", createdFeature);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Feature value = _featureService.TGetByFilter(x => x.Id == id);
        _featureService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateFeatureRequestDto updateFeatureRequestDto)
    {
        Feature mappedFeature = _mapper.Map<Feature>(updateFeatureRequestDto);
        Feature value = _featureService.TUpdate(mappedFeature);
        UpdatedFeatureResponseDto updatedFeature = _mapper.Map<UpdatedFeatureResponseDto>(value);
        return Ok(updatedFeature);
    }
    [HttpGet("getbyid")]
    public IActionResult Get(int id)
    {
        Feature value = _featureService.TGetByFilter(x => x.Id == id);
        GetFeatureResponseDto getFeature = _mapper.Map<GetFeatureResponseDto>(value);
        return Ok(getFeature);
    }
}
