
using DomainComponent.Entities;

namespace ApplicationComponent
{
    public interface ICommonService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task AddAsync(TEntity entity);
    }
}
