

namespace _2_Services
{
    public interface IRepositorySimple<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
