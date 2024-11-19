using _06_demo_basicauth_asp.Models;

namespace _06_demo_basicauth_asp.Services
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>()
        {
            new User() { Email = "User1@gmail.com", Password = "123456" },
            new User() { Email = "User2@gmail.com", Password = "123456" }
        };
        public bool IsUser(string email, string pass)
            => users.Where(u => u.Email == email && u.Password == pass).Count() > 0;
    }
}
