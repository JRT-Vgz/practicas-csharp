using ProjectFinalDemo.Domain.Entities;
using ProjectFinalDemo.Domain.Repositories;
using ProjectFinalDemo.Infrastructure.Data.Data;

namespace ProjectFinalDemo.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public UserEntity GetByUserName(string username)
        {
            return this._context.Users.FirstOrDefault(x => x.UserName.Equals(username));
        }


        public bool Login(string username, string password)
        {
            UserEntity user = GetByUserName(username) ?? throw new Exception("El usuario no existe");

            if (!user.Password.Equals(password))
            {
                throw new Exception("Contraseña incorrecta");
            }
            return true;
        }
    }
}
