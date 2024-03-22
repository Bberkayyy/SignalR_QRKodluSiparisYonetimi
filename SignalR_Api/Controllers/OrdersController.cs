using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.OrderDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService OrderService, IMapper mapper)
    {
        _orderService = OrderService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllOrderResponseDto> values = _mapper.Map<IList<GetAllOrderResponseDto>>(_orderService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateOrderRequestDto createOrderRequestDto)
    {
        Order mappedOrder = _mapper.Map<Order>(createOrderRequestDto);
        Order value = _orderService.TAdd(mappedOrder);
        CreatedOrderResponseDto createdOrder = _mapper.Map<CreatedOrderResponseDto>(value);
        return Created("", createdOrder);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Order value = _orderService.TGetByFilter(x => x.Id == id);
        _orderService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateOrderRequestDto updateOrderRequestDto)
    {
        Order mappedOrder = _mapper.Map<Order>(updateOrderRequestDto);
        Order value = _orderService.TUpdate(mappedOrder);
        UpdatedOrderResponseDto updatedOrder = _mapper.Map<UpdatedOrderResponseDto>(value);
        return Ok(updatedOrder);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Order value = _orderService.TGetByFilter(x => x.Id == id);
        GetOrderResponseDto getOrder = _mapper.Map<GetOrderResponseDto>(value);
        return Ok(getOrder);
    }
}
