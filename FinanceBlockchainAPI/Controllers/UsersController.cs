using FinanceBlockchain.Application.UseCases.CreateUser;
using FinanceBlockchain.Application.UseCases.AuthenticateUser;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBlockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly AuthenticateUserHandler _authenticateUserHandler;

        public UsersController(CreateUserHandler createUserHandler, AuthenticateUserHandler authenticateUserHandler)
        {
            _createUserHandler = createUserHandler;
            _authenticateUserHandler = authenticateUserHandler;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserRequest request)
        {
            var response = _createUserHandler.Handle(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateUserRequest request)
        {
            var response = _authenticateUserHandler.Handle(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return Unauthorized(response);
        }
    }
}
