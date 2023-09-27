using Chat.Services.Interfaces.Auth;
using Chat.Services.Interfaces.Common;
using Chat.Services.Interfaces.Messages;
using Chat.Services.Interfaces.Notifications;
using Chat.Services.Interfaces.Users;
using Chat.Services.Services.Auth;
using Chat.Services.Services.Common;
using Chat.Services.Services.Messages;
using Chat.Services.Services.Notifications;
using Chat.Services.Services.Users;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.Design;

namespace Chat.WebApi.Configuration.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IUserAuthService, UserAuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
        builder.Services.AddScoped<IMessageService, MessageService>();
    }
}
