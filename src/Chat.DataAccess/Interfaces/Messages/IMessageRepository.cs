using Chat.DataAccess.Common;
using Chat.Domain.Entities.Messages;

namespace Chat.DataAccess.Interfaces.Messages;

public interface IMessageRepository : IRepository<Message, Message>,
    IGetAll<Message>
{
    public Task<IList<Message>> GetByIdMessages(long userOneId, long userTwoId);
}
