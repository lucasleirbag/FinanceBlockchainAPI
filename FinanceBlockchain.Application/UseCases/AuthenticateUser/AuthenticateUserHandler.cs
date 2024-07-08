using FinanceBlockchain.Application.Interfaces;

namespace FinanceBlockchain.Application.UseCases.AuthenticateUser
{
    public class AuthenticateUserHandler
    {
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public AuthenticateUserResponse Handle(AuthenticateUserRequest request)
        {
            return _userService.AuthenticateUser(request);
        }
    }
}
