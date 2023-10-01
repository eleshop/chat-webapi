using Chat.Application.Exceptions.Files;
using Chat.Application.Exceptions.Messages;
using Chat.DataAccess.Interfaces;
using Chat.DataAccess.Interfaces.Messages;
using Chat.Domain.Entities.Messages;
using Chat.Persistence.Dtos.Messages;
using Chat.Persistence.Helpers;
using Chat.Services.Interfaces.Common;
using Chat.Services.Interfaces.Messages;

namespace Chat.Services.Services.Messages;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _repository;
    private readonly IFileService _fileService;

    public MessageService(IMessageRepository repository,
        IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<int> CreateAsync(MessageCreateDto entity)
    {

        Message message = new Message()
        {
            SenderId = entity.SenderId,
            Messages = entity.Messages,
            RecipientId = entity.RecipientId,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _repository.CreateAsync(message);

        return result;
    }

    public async Task<int> DeleteAsync(long id)
    {

        var dbResult = await _repository.DeleteAsync(id);

        return dbResult;
    }

    public async Task<IList<Message>> GetAllAsync()
    {
        var message = await _repository.GetAllAsync();
        return message;
    }

    public async Task<Message?> GetByIdAsync(long id)
    {
        var message = await _repository.GetByIdAsync(id);
        if (message == null) throw new MessageNotFoundException();
        else return message;
    }

    public async Task<IList<Message>> GetByIdMessages(long userOneId, long userTwoId)
    {
        var message = await _repository.GetByIdMessages(userOneId, userTwoId);
        return message;
    }

    public async Task<int> UpdateAsync(long id, MessageUpdateDto entity)
    {
        var message = await _repository.GetByIdAsync(id);
        if (message == null) throw new MessageNotFoundException();

        // update productDetailFashion with new items 
        message.Messages = entity.Messages;
        message.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(id, message);

        return dbResult;
    }
}
