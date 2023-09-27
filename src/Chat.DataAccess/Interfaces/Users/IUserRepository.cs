using Chat.DataAccess.Common;
using Chat.DataAccess.ViewModels.Users;
using Chat.Domain.Entities.Users;

namespace Chat.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
