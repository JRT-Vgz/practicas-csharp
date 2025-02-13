namespace ProjectFinalDemo.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetByIdSync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        void Add(T entity);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}