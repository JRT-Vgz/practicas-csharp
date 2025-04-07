
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemRepository : IRepository
    {
        private readonly ItemsDBContext _context;

        public ItemRepository(ItemsDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var itemModels = await _context.ItemsModel.ToListAsync();

            return itemModels.Select(i => new Item(i.Id, i.Title, i.IsCompleted));
        }

        public async Task AddAsync(Item item)
        {
            var itemModel = new ItemModel
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedDate = DateTime.Now
            };

            await _context.ItemsModel.AddAsync(itemModel);
            await _context.SaveChangesAsync();
        }
    }
}
