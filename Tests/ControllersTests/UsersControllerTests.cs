using FinanceBlockchain.API.Controllers;
using FinanceBlockchain.Application.UseCases.CreateUser;
using FinanceBlockchain.Application.UseCases.AuthenticateUser;
using FinanceBlockchain.Application.Interfaces;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBlockchain.Tests.ControllersTests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();

            var createUserHandler = new CreateUserHandler(_userServiceMock.Object);
            var authenticateUserHandler = new AuthenticateUserHandler(_userServiceMock.Object);

            _controller = new UsersController(createUserHandler, authenticateUserHandler);
        }

        [Fact]
        public void Register_DeveRetornarOkResultParaUsuarioValido()
        {
            var request = new CreateUserRequest
            {
                Nome = "Test User",
                Email = "test@example.com",
                HashSenha = "hashed_password",
                ChavePublica = "public_key",
                ChavePrivada = "private_key"
            };

            _userServiceMock.Setup(x => x.CreateUser(It.IsAny<CreateUserRequest>())).Returns(new CreateUserResponse { Success = true });

            var result = _controller.Register(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Register_DeveRetornarBadRequestParaUsuarioInvalido()
        {
            var request = new CreateUserRequest
            {
                Nome = "Test User",
                Email = "test@example.com",
                HashSenha = "hashed_password",
                ChavePublica = "public_key",
                ChavePrivada = "private_key"
            };

            _userServiceMock.Setup(x => x.CreateUser(It.IsAny<CreateUserRequest>())).Returns(new CreateUserResponse { Success = false });

            var result = _controller.Register(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Login_DeveRetornarOkResultParaCredenciaisValidas()
        {
            var request = new AuthenticateUserRequest
            {
                Email = "test@example.com",
                Senha = "password"
            };

            _userServiceMock.Setup(x => x.AuthenticateUser(It.IsAny<AuthenticateUserRequest>())).Returns(new AuthenticateUserResponse { Success = true, Token = "jwt_token" });

            var result = _controller.Login(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_DeveRetornarUnauthorizedResultParaCredenciaisInvalidas()
        {
            var request = new AuthenticateUserRequest
            {
                Email = "test@example.com",
                Senha = "password"
            };

            _userServiceMock.Setup(x => x.AuthenticateUser(It.IsAny<AuthenticateUserRequest>())).Returns(new AuthenticateUserResponse { Success = false });

            var result = _controller.Login(request);

            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
