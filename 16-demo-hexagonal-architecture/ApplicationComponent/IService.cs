
using DomainComponent.Entities;

namespace ApplicationComponent
{
    public interface IService
    {
        Task<IEnumerable<Item>> GetAsync();
        Task AddAsync(string title);
    }
}
