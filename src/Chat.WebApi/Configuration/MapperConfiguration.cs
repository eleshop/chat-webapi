using AutoMapper;
using Chat.Domain.Entities.Messages;
using Chat.Domain.Entities.Users;
using Chat.Persistence.Dtos.Messages;
using Chat.Persistence.Dtos.Users;

namespace Chat.WebApi.Configuration.Layers;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<MessageCreateDto, Message>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
    }
}
