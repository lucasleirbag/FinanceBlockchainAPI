using FinanceBlockchain.Application.UseCases.CreateTransaction;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBlockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly CreateTransactionHandler _createTransactionHandler;

        public TransactionsController(CreateTransactionHandler createTransactionHandler)
        {
            _createTransactionHandler = createTransactionHandler;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateTransactionRequest request)
        {
            var response = _createTransactionHandler.Handle(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
