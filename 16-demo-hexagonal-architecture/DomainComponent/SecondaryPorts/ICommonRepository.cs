
using DomainComponent.Entities;

namespace DomainComponent.SecondaryPorts
{
    public interface ICommonRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
    }
}
