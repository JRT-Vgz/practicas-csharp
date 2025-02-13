using ProjectFinalDemo.Domain.Entities;
using ProjectFinalDemo.Domain.Repositories;
using ProjectFinalDemo.Infrastructure.Data.Data;

namespace ProjectFinalDemo.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}