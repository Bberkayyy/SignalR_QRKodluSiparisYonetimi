using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_BusinessLayer.Abstract.BusinessInterfaces;
using SignalR_DtoLayer.NotificationDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public NotificationsController(INotificationService NotificationService, IMapper mapper)
    {
        _notificationService = NotificationService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllNotificationResponseDto> values = _mapper.Map<IList<GetAllNotificationResponseDto>>(_notificationService.TGetAll());
        return Ok(values);
    }
    [HttpGet("getallbystatusfalse")]
    public IActionResult GetAllByStatusFalse()
    {
        IList<GetAllNotificationByStatusFalseResponseDto> values = _mapper.Map<IList<GetAllNotificationByStatusFalseResponseDto>>(_notificationService.TGetAllNotificationByStatusFalse());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateNotificationRequestDto createNotificationRequestDto)
    {
        Notification mappedNotification = _mapper.Map<Notification>(createNotificationRequestDto);
        Notification value = _notificationService.TAdd(mappedNotification);
        CreatedNotificationResponseDto createdNotification = _mapper.Map<CreatedNotificationResponseDto>(value);
        return Created("", createdNotification);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Notification value = _notificationService.TGetByFilter(x => x.Id == id);
        _notificationService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateNotificationRequestDto updateNotificationRequestDto)
    {
        Notification mappedNotification = _mapper.Map<Notification>(updateNotificationRequestDto);
        Notification value = _notificationService.TUpdate(mappedNotification);
        UpdatedNotificationResponseDto updatedNotification = _mapper.Map<UpdatedNotificationResponseDto>(value);
        return Ok(updatedNotification);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Notification value = _notificationService.TGetByFilter(x => x.Id == id);
        GetNotificationResponseDto getNotification = _mapper.Map<GetNotificationResponseDto>(value);
        return Ok(getNotification);
    }
    [HttpGet("notificationcountbystatusfalse")]
    public IActionResult GetNotificationCountByStatusFalse()
    {
        return Ok(_notificationService.TGetNotificationCountByStatusFalse());
    }
    [HttpGet("notificationstatustotrue")]
    public IActionResult NotificationStatusToTrue(int id)
    {
        _notificationService.TNotificationStatusToTrue(id);
        return Ok("Bildirim durumu okundu olarak işaretlendi.");
    }
    [HttpGet("notificationstatustofalse")]
    public IActionResult NotificationStatusToFalse(int id)
    {
        _notificationService.TNotificationStatusToFalse(id);
        return Ok("Bildirim durumu okunmadı olarak işaretlendi.");
    }
}
