using FinanceBlockchain.Application.Interfaces;
using FinanceBlockchain.Application.UseCases.MineBlock;
using FinanceBlockchain.Application.UseCases.ValidateBlockchain;
using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;

namespace FinanceBlockchain.Application.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly IBlockRepository _blockRepository;

        public BlockchainService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public MineBlockResponse MineBlock(MineBlockRequest request)
        {
            // Lógica de mineração omitida por simplicidade
            var block = new Block
            {
                ID = Guid.NewGuid(),
                HashBlocoAnterior = request.HashBlocoAnterior,
                ListaTransacoes = request.ListaTransacoes,
                Timestamp = DateTime.Now,
                Nonce = request.Nonce
            };

            _blockRepository.Adicionar(block);

            return new MineBlockResponse { Success = true, BlockId = block.ID };
        }

        public ValidateBlockchainResponse ValidateBlockchain()
        {
            // Lógica de validação omitida por simplicidade
            return new ValidateBlockchainResponse { Success = true };
        }
    }
}
