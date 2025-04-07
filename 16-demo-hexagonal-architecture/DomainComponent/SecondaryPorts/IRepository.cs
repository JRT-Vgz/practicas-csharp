
using DomainComponent.Entities;

namespace DomainComponent.SecondaryPorts
{
    public interface IRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task AddAsync(Item item);
    }
}
