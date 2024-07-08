using FinanceBlockchain.Application.UseCases.CreateUser;
using FinanceBlockchain.Application.UseCases.AuthenticateUser;

namespace FinanceBlockchain.Application.Interfaces
{
    public interface IUserService
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
}
