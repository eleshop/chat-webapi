using Chat.DataAccess.Interfaces.Users;
using Chat.DataAccess.ViewModels.Users;
using Chat.Domain.Entities.Users;
using Dapper;

namespace Chat.DataAccess.Repositories.Users;

public class UsersRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, " +
                "password_hash, salt, avatar, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, " +
                    "@PasswordHash, @Salt, @Avatar, @CreatedAt, @UpdatedAt);";

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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<UserViewModel>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM public.user_view Order By id Desc";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From users where id=@Id";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.users SET " +
                "first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, phone_number_confirmed=@PhoneNumberConfirmed, " +
                    "password_hash=@PasswordHash, salt=@Salt, avatar=@Avatar, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id};";

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
