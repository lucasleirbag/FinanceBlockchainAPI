using FinanceBlockchain.Application.UseCases.MineBlock;
using FinanceBlockchain.Application.UseCases.ValidateBlockchain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBlockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockchainController : ControllerBase
    {
        private readonly MineBlockHandler _mineBlockHandler;
        private readonly ValidateBlockchainHandler _validateBlockchainHandler;

        public BlockchainController(MineBlockHandler mineBlockHandler, ValidateBlockchainHandler validateBlockchainHandler)
        {
            _mineBlockHandler = mineBlockHandler;
            _validateBlockchainHandler = validateBlockchainHandler;
        }

        [HttpPost("mine")]
        public IActionResult Mine([FromBody] MineBlockRequest request)
        {
            var response = _mineBlockHandler.Handle(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("validate")]
        public IActionResult Validate()
        {
            var response = _validateBlockchainHandler.Handle(new ValidateBlockchainRequest());
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public IActionResult GetBlockchain()
        {
            // Implementar lógica para obter a blockchain completa
            return Ok();
        }
    }
}
