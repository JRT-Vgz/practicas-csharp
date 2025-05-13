
namespace DomainComponent.SecondaryPorts
{
    public interface IGetRepository<TEntity>
    {
        Task<TEntity?> GetByIdAsync(int id);
    }
}
