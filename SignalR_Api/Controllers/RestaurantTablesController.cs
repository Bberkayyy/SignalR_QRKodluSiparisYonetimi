using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.RestaurantTableDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantTablesController : ControllerBase
{
    private readonly IRestaurantTableService _restaurantTableService;
    private readonly IMapper _mapper;

    public RestaurantTablesController(IRestaurantTableService RestaurantTableService, IMapper mapper)
    {
        _restaurantTableService = RestaurantTableService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllRestaurantTableResponseDto> values = _mapper.Map<IList<GetAllRestaurantTableResponseDto>>(_restaurantTableService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateRestaurantTableRequestDto createRestaurantTableRequestDto)
    {
        RestaurantTable mappedRestaurantTable = _mapper.Map<RestaurantTable>(createRestaurantTableRequestDto);
        RestaurantTable value = _restaurantTableService.TAdd(mappedRestaurantTable);
        CreatedRestaurantTableResponseDto createdRestaurantTable = _mapper.Map<CreatedRestaurantTableResponseDto>(value);
        return Created("", createdRestaurantTable);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        RestaurantTable value = _restaurantTableService.TGetByFilter(x => x.Id == id);
        _restaurantTableService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateRestaurantTableRequestDto updateRestaurantTableRequestDto)
    {
        RestaurantTable mappedRestaurantTable = _mapper.Map<RestaurantTable>(updateRestaurantTableRequestDto);
        RestaurantTable value = _restaurantTableService.TUpdate(mappedRestaurantTable);
        UpdatedRestaurantTableResponseDto updatedRestaurantTable = _mapper.Map<UpdatedRestaurantTableResponseDto>(value);
        return Ok(updatedRestaurantTable);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        RestaurantTable value = _restaurantTableService.TGetByFilter(x => x.Id == id);
        GetRestaurantTableResponseDto getRestaurantTable = _mapper.Map<GetRestaurantTableResponseDto>(value);
        return Ok(getRestaurantTable);
    }
}
