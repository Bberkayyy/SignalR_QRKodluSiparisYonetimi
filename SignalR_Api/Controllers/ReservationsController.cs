using AutoMapper;
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

    public ReservationsController(IReservationService ReservationService, IMapper mapper)
    {
        _reservationService = ReservationService;
        _mapper = mapper;
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
}
