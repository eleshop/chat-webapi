using Chat.Persistence.Dtos.Notifications;

namespace Chat.Services.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
