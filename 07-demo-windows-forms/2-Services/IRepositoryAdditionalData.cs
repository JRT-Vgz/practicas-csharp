
namespace _2_Services
{
    public interface IRepositoryAdditionalData<T, TAdditionalData>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<(T, TAdditionalData)> GetByIdAsync(int id);
        Task AddAsync(T entity, TAdditionalData additionalData);
        Task EditAsync(T entity, TAdditionalData additionalData);
        Task DeleteAsync(int id);
    }
}
