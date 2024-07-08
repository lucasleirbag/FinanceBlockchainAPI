using FinanceBlockchain.Application.Interfaces;

namespace FinanceBlockchain.Application.UseCases.ValidateBlockchain
{
    public class ValidateBlockchainHandler
    {
        private readonly IBlockchainService _blockchainService;

        public ValidateBlockchainHandler(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public ValidateBlockchainResponse Handle(ValidateBlockchainRequest request)
        {
            return _blockchainService.ValidateBlockchain();
        }
    }
}
