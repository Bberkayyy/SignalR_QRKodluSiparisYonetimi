using AutoMapper;
using SignalR_DtoLayer.ReservationDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class ReservationMapping : Profile
{
    public ReservationMapping()
    {
        CreateMap<Reservation, GetAllReservationResponseDto>().ReverseMap();
        CreateMap<Reservation, GetReservationResponseDto>().ReverseMap();
        CreateMap<Reservation, CreateReservationRequestDto>().ReverseMap();
        CreateMap<Reservation, CreatedReservationResponseDto>().ReverseMap();
        CreateMap<Reservation, UpdateReservationRequestDto>().ReverseMap();
        CreateMap<Reservation, UpdatedReservationResponseDto>().ReverseMap();
    }
}
