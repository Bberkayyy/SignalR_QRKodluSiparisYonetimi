using AutoMapper;
using SignalR_DtoLayer.MessageDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, CreateMessageRequestDto>().ReverseMap();
        CreateMap<Message, CreatedMessageResponseDto>().ReverseMap();
        CreateMap<Message, GetAllMessageResponseDto>().ReverseMap();
        CreateMap<Message, GetMessageResponseDto>().ReverseMap();
        CreateMap<Message, UpdateMessageRequestDto>().ReverseMap();
        CreateMap<Message, UpdatedMessageResponseDto>().ReverseMap();
    }
}
