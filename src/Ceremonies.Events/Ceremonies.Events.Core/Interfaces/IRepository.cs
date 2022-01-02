namespace Ceremonies.Events.Core.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> ListAsync<T>() where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
