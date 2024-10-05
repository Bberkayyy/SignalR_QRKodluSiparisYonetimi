using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.ReservationDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateReservationRequestDto> _validator;

    public ReservationsController(IReservationService ReservationService, IMapper mapper, IValidator<CreateReservationRequestDto> validator)
    {
        _reservationService = ReservationService;
        _mapper = mapper;
        _validator = validator;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllReservationResponseDto> values = _mapper.Map<IList<GetAllReservationResponseDto>>(_reservationService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateReservationRequestDto createReservationRequestDto)
    {
        ValidationResult validationResult = _validator.Validate(createReservationRequestDto);
        if (!validationResult.IsValid)
        {
            //List<string> errorMessages = new();
            //foreach (var item in validationResult.Errors)
            //{
            //    errorMessages.Add(item.ErrorMessage);
            //}
            return BadRequest(validationResult.Errors);
        }

        Reservation mappedReservation = _mapper.Map<Reservation>(createReservationRequestDto);
        Reservation value = _reservationService.TAdd(mappedReservation);
        CreatedReservationResponseDto createdReservation = _mapper.Map<CreatedReservationResponseDto>(value);
        return Created("", createdReservation);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Reservation value = _reservationService.TGetByFilter(x => x.Id == id);
        _reservationService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateReservationRequestDto updateReservationRequestDto)
    {
        Reservation mappedReservation = _mapper.Map<Reservation>(updateReservationRequestDto);
        Reservation value = _reservationService.TUpdate(mappedReservation);
        UpdatedReservationResponseDto updatedReservation = _mapper.Map<UpdatedReservationResponseDto>(value);
        return Ok(updatedReservation);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Reservation value = _reservationService.TGetByFilter(x => x.Id == id);
        GetReservationResponseDto getReservation = _mapper.Map<GetReservationResponseDto>(value);
        return Ok(getReservation);
    }
    [HttpGet("approved")]
    public IActionResult ReservationStatusApproved(int id)
    {
        _reservationService.TReservationStatusApproved(id);
        return Ok("Rezervasyon onaylandı.");
    }
    [HttpGet("cancelled")]
    public IActionResult ReservationStatusCancelled(int id)
    {
        _reservationService.TReservationStatusCancelled(id);
        return Ok("Rezervasyon iptal edildi.");
    }
}
