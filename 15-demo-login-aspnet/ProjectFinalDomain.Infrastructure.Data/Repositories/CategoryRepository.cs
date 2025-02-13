using ProjectFinalDemo.Domain.Entities;
using ProjectFinalDemo.Domain.Repositories;
using ProjectFinalDemo.Infrastructure.Data.Data;

namespace ProjectFinalDemo.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
