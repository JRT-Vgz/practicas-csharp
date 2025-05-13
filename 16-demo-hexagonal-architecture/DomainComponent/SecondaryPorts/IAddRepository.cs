
namespace DomainComponent.SecondaryPorts
{
    public interface IAddRepository<TModel>
    {
        Task AddAsync(TModel model);
    }
}
