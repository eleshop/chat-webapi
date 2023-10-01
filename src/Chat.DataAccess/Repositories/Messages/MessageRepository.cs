using Chat.DataAccess.Interfaces.Messages;
using Chat.Domain.Entities.Messages;
using Dapper;

namespace Chat.DataAccess.Repositories.Messages;

public class MessageRepository : BaseRepository, IMessageRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM messages";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Message entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.messages " +
                "(sender_id, messages, recipient_id, created_at, updated_at) " +
                    "VALUES (@SenderId, @Messages, @RecipientId, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM messages WHERE id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Message>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM messages ORDER BY id DESC ";

            var result = (await _connection.QueryAsync<Message>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Message>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Message?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Message>> GetByIdMessages(long userOneId, long userTwoId)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = $"SELECT * FROM messages " +
                $"where sender_id = {userOneId} and recipient_id = {userTwoId} or " +
                $"sender_id = {userTwoId} and recipient_id = {userOneId} ORDER BY created_at ASC";
            
            var result = (await _connection.QueryAsync<Message>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Message>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Message entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.messages " +
                $"SET sender_id=@SenderId, messages=@Messages, recipient_id=@RecipientId, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id=@Id;";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
