using Chat.Domain.Entities.Messages;
using Chat.Persistence.Dtos.Messages;

namespace Chat.Services.Interfaces.Messages;

public interface IMessageService
{
    public Task<IList<Message>> GetByIdMessages(long userOneId, long userTwoId);

    public Task<IList<Message>> GetAllAsync();

    public Task<int> CreateAsync(MessageCreateDto entity);

    public Task<int> UpdateAsync(long id, MessageUpdateDto entity);

    public Task<int> DeleteAsync(long id);

    public Task<Message?> GetByIdAsync(long id);

    public Task<long> CountAsync();
}
