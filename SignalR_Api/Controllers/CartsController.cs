using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.CartDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly IMapper _mapper;

    public CartsController(ICartService CartService, IMapper mapper)
    {
        _cartService = CartService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllCartResponseDto> values = _mapper.Map<IList<GetAllCartResponseDto>>(_cartService.TGetAll());
        return Ok(values);
    }
    [HttpGet("getallwithrelationships")]
    public IActionResult GetAllWithRelationships()
    {
        IList<GetAllCartWithRelationshipsResponseDto> values = _mapper.Map<IList<GetAllCartWithRelationshipsResponseDto>>(_cartService.TGetAllCartsWithRelationships());
        return Ok(values);
    }
    [HttpGet("getallbytableid")]
    public IActionResult GetByTableId(int id)
    {
        IList<GetAllCartResponseDto> values = _mapper.Map<IList<GetAllCartResponseDto>>(_cartService.TGetCartListByRestaurantTableId(id));
        return Ok(values);
    }
    [HttpGet("getallbytableidwithrelationships")]
    public IActionResult GetByTableIdWithRelationships(int id)
    {
        IList<GetAllCartWithRelationshipsResponseDto> values = _mapper.Map<IList<GetAllCartWithRelationshipsResponseDto>>(_cartService.TGetCartListByRestaurantTableIdWithRelationships(id));
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateCartRequestDto createCartRequestDto)
    {
        Cart mappedCart = _mapper.Map<Cart>(createCartRequestDto);
        Cart value = _cartService.TAdd(mappedCart);
        CreatedCartResponseDto createdCart = _mapper.Map<CreatedCartResponseDto>(value);
        return Created("", createdCart);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Cart value = _cartService.TGetByFilter(x => x.Id == id);
        _cartService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateCartRequestDto updateCartRequestDto)
    {
        Cart mappedCart = _mapper.Map<Cart>(updateCartRequestDto);
        Cart value = _cartService.TUpdate(mappedCart);
        UpdatedCartResponseDto updatedCart = _mapper.Map<UpdatedCartResponseDto>(value);
        return Ok(updatedCart);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Cart value = _cartService.TGetByFilter(x => x.Id == id);
        GetCartResponseDto getCart = _mapper.Map<GetCartResponseDto>(value);
        return Ok(getCart);
    }
    [HttpGet("getwithrelationships")]
    public IActionResult GetCartWithRelationships(int id)
    {
        Cart value = _cartService.TGetCartWithRelationships(id);
        GetCartWithRelationshipsResponseDto getCart = _mapper.Map<GetCartWithRelationshipsResponseDto>(value);
        return Ok(getCart);
    }
}
