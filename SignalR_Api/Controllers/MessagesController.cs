using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.MessageDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessagesController(IMessageService MessageService, IMapper mapper)
    {
        _messageService = MessageService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllMessageResponseDto> values = _mapper.Map<IList<GetAllMessageResponseDto>>(_messageService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateMessageRequestDto createMessageRequestDto)
    {
        Message mappedMessage = _mapper.Map<Message>(createMessageRequestDto);
        Message value = _messageService.TAdd(mappedMessage);
        CreatedMessageResponseDto createdMessage = _mapper.Map<CreatedMessageResponseDto>(value);
        return Created("", createdMessage);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Message value = _messageService.TGetByFilter(x => x.Id == id);
        _messageService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateMessageRequestDto updateMessageRequestDto)
    {
        Message mappedMessage = _mapper.Map<Message>(updateMessageRequestDto);
        Message value = _messageService.TUpdate(mappedMessage);
        UpdatedMessageResponseDto updatedMessage = _mapper.Map<UpdatedMessageResponseDto>(value);
        return Ok(updatedMessage);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Message value = _messageService.TGetByFilter(x => x.Id == id);
        GetMessageResponseDto getMessage = _mapper.Map<GetMessageResponseDto>(value);
        return Ok(getMessage);
    }
}
