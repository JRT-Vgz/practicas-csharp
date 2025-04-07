using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;

namespace ApplicationComponent
{
    public class ItemService : IService
    {
        private readonly IRepository _repository;

        public ItemService(IRepository repository)
        {
        _repository = repository; 
        }

        public async Task<IEnumerable<Item>> GetAsync() 
            => await _repository.GetAllAsync();

        public async Task AddAsync(string title)
        {
            var item = new Item(0, title, false);
            await _repository.AddAsync(item);
        }
    }
}
