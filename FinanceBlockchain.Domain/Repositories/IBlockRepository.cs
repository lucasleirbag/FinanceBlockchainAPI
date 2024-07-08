using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Domain.Repositories
{
    public interface IBlockRepository
    {
        void Adicionar(Block block);
        void Atualizar(Block block);
        void Remover(Block block);
        Block ObterPorId(Guid id);
        Block ObterUltimoBloco();
    }
}
