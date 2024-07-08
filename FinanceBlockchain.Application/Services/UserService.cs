using FinanceBlockchain.Application.Interfaces;
using FinanceBlockchain.Application.UseCases.CreateUser;
using FinanceBlockchain.Application.UseCases.AuthenticateUser;
using FinanceBlockchain.Domain.Repositories;
using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            var user = new User
            {
                ID = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                HashSenha = request.HashSenha,
                ChavePublica = request.ChavePublica,
                ChavePrivada = request.ChavePrivada
            };

            _userRepository.Adicionar(user);

            return new CreateUserResponse { Success = true, UserId = user.ID };
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            var user = _userRepository.ObterPorEmail(request.Email);
            if (user == null || !user.Autenticar(request.Senha))
            {
                return new AuthenticateUserResponse { Success = false };
            }

            // Geração do token JWT omitida por simplicidade
            return new AuthenticateUserResponse { Success = true, Token = "jwt_token" };
        }
    }
}
