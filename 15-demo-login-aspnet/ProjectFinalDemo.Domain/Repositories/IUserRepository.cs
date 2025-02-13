using ProjectFinalDemo.Domain.Entities;

namespace ProjectFinalDemo.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetByUserName(string username);
        bool Login(string username, string password);
    }
}
