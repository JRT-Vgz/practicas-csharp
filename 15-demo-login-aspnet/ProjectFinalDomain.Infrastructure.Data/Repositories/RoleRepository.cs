using ProjectFinalDemo.Domain.Entities;
using ProjectFinalDemo.Domain.Repositories;
using ProjectFinalDemo.Infrastructure.Data.Data;

namespace ProjectFinalDemo.Infrastructure.Data.Repositories
{
    public class RoleRepository : GenericRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {
            
        }
    }
}
