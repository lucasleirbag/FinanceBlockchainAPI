using FinanceBlockchain.Application.UseCases.MineBlock;
using FinanceBlockchain.Application.UseCases.ValidateBlockchain;

namespace FinanceBlockchain.Application.Interfaces
{
    public interface IBlockchainService
    {
        MineBlockResponse MineBlock(MineBlockRequest request);
        ValidateBlockchainResponse ValidateBlockchain();
    }
}
