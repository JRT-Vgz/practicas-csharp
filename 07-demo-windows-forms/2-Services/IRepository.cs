
namespace _2_Services
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(int id);
    }
}
