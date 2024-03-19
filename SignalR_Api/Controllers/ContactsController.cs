using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.ContactDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ContactsController(IContactService ContactService, IMapper mapper)
    {
        _contactService = ContactService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllContactResponseDto> values = _mapper.Map<IList<GetAllContactResponseDto>>(_contactService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateContactRequestDto createContactRequestDto)
    {
        Contact mappedContact = _mapper.Map<Contact>(createContactRequestDto);
        Contact value = _contactService.TAdd(mappedContact);
        CreatedContactResponseDto createdContact = _mapper.Map<CreatedContactResponseDto>(value);
        return Created("", createdContact);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Contact value = _contactService.TGetByFilter(x => x.Id == id);
        _contactService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateContactRequestDto updateContactRequestDto)
    {
        Contact mappedContact = _mapper.Map<Contact>(updateContactRequestDto);
        Contact value = _contactService.TUpdate(mappedContact);
        UpdatedContactResponseDto updatedContact = _mapper.Map<UpdatedContactResponseDto>(value);
        return Ok(updatedContact);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Contact value = _contactService.TGetByFilter(x => x.Id == id);
        GetContactResponseDto getContact = _mapper.Map<GetContactResponseDto>(value);
        return Ok(getContact);
    }
}
