namespace Chat.DataAccess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync();
}
