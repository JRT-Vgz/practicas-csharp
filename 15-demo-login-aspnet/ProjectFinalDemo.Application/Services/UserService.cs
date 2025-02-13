using ProjectFinalDemo.Application.Models.Users;
using ProjectFinalDemo.Application.Services.Interfaces;
using ProjectFinalDemo.Domain.Repositories;

namespace ProjectFinalDemo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IJWTService _jwtService;
        private readonly IUserRepository _userRepository;

        public UserService(IJWTService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public async Task<string> Login(LoginRequestModel request)
        {
            var loginSuccess = _userRepository.Login(request.UserName, request.Password);

            if (loginSuccess) { return _jwtService.GenerateToken(request.UserName); }

            return "Ha ocurrido un error al intentar logearse";

        }
    }
}
