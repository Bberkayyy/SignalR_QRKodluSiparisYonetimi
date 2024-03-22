using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.OrderDetailDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;

    public OrderDetailsController(IOrderDetailService OrderDetailService, IMapper mapper)
    {
        _orderDetailService = OrderDetailService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllOrderDetailResponseDto> values = _mapper.Map<IList<GetAllOrderDetailResponseDto>>(_orderDetailService.TGetAll());
        return Ok(values);
    }
    [HttpGet("getallwithrelationships")]
    public IActionResult GetAllWithRelationships()
    {
        IList<GetAllOrderDetailWithRelationshipsResponseDto> values = _mapper.Map<IList<GetAllOrderDetailWithRelationshipsResponseDto>>(_orderDetailService.TGetAllOrderDetailsWithRelationships());
        return Ok(values);
    }
    [HttpGet("getwithcategory/{id}")]
    public IActionResult GetOrderDetailWithRelationships(int id)
    {
        GetOrderDetailWithRelationshipsResponseDto value = _mapper.Map<GetOrderDetailWithRelationshipsResponseDto>(_orderDetailService.TGetOrderDetailWithRelationships(id));
        return Ok(value);
    }
    [HttpPost]
    public IActionResult Create(CreateOrderDetailRequestDto createOrderDetailRequestDto)
    {
        OrderDetail mappedOrderDetail = _mapper.Map<OrderDetail>(createOrderDetailRequestDto);
        OrderDetail value = _orderDetailService.TAdd(mappedOrderDetail);
        CreatedOrderDetailResponseDto createdOrderDetail = _mapper.Map<CreatedOrderDetailResponseDto>(value);
        return Created("", createdOrderDetail);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        OrderDetail value = _orderDetailService.TGetByFilter(x => x.Id == id);
        _orderDetailService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateOrderDetailRequestDto updateOrderDetailRequestDto)
    {
        OrderDetail mappedOrderDetail = _mapper.Map<OrderDetail>(updateOrderDetailRequestDto);
        OrderDetail value = _orderDetailService.TUpdate(mappedOrderDetail);
        UpdatedOrderDetailResponseDto updatedOrderDetail = _mapper.Map<UpdatedOrderDetailResponseDto>(value);
        return Ok(updatedOrderDetail);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        OrderDetail value = _orderDetailService.TGetByFilter(x => x.Id == id);
        GetOrderDetailResponseDto getOrderDetail = _mapper.Map<GetOrderDetailResponseDto>(value);
        return Ok(getOrderDetail);
    }
}
