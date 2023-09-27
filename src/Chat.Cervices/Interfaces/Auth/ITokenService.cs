using Chat.Domain.Entities.Users;

namespace Chat.Services.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
