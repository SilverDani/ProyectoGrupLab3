namespace TecnoService.Core.Interfaces.Service
{
    public interface IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int idID);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int ID);
    }
}
