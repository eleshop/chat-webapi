using Chat.DataAccess.Interfaces.Messages;
using Chat.DataAccess.Interfaces.Users;
using Chat.DataAccess.Repositories.Messages;
using Chat.DataAccess.Repositories.Users;

namespace Chat.WebApi.Configuration.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IUserRepository, UsersRepository>();
        builder.Services.AddScoped<IMessageRepository, MessageRepository>();
    }
}
