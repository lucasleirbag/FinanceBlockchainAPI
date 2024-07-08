using FinanceBlockchain.Application.Interfaces;

namespace FinanceBlockchain.Application.UseCases.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public CreateUserResponse Handle(CreateUserRequest request)
        {
            return _userService.CreateUser(request);
        }
    }
}
