using AutoMapper;
using SignalR_DtoLayer.NotificationDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<Notification, GetAllNotificationResponseDto>().ReverseMap();
        CreateMap<Notification, GetAllNotificationByStatusFalseResponseDto>().ReverseMap();
        CreateMap<Notification, GetNotificationResponseDto>().ReverseMap();
        CreateMap<Notification, CreateNotificationRequestDto>().ReverseMap();
        CreateMap<Notification, CreatedNotificationResponseDto>().ReverseMap();
        CreateMap<Notification, UpdateNotificationRequestDto>().ReverseMap();
        CreateMap<Notification, UpdatedNotificationResponseDto>().ReverseMap();
    }
}
