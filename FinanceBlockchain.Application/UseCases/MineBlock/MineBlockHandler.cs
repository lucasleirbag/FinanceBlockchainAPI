using FinanceBlockchain.Application.Interfaces;

namespace FinanceBlockchain.Application.UseCases.MineBlock
{
    public class MineBlockHandler
    {
        private readonly IBlockchainService _blockchainService;

        public MineBlockHandler(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public MineBlockResponse Handle(MineBlockRequest request)
        {
            return _blockchainService.MineBlock(request);
        }
    }
}
