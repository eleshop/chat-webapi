using Chat.DataAccess.ViewModels.Users;
using Chat.Persistence.Dtos.Users;

namespace Chat.Services.Interfaces.Users;

public interface IUserService
{
    public Task<IList<UserViewModel>> GetAllAsync();

    public Task<UserViewModel> GetByIdAsync(long id);

    public Task<bool> UpdateAsync(long userId, string phone, UserUpdateDto dto);
}
