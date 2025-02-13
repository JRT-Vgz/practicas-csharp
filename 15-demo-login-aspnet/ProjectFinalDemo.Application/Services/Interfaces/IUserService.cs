using ProjectFinalDemo.Application.Models.Users;

namespace ProjectFinalDemo.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginRequestModel request);
    }
}
