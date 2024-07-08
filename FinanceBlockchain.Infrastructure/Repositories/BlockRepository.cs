using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using FinanceBlockchain.Infrastructure.Data;

namespace FinanceBlockchain.Infrastructure.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly ApplicationDbContext _context;

        public BlockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Block block)
        {
            _context.Blocks.Add(block);
            _context.SaveChanges();
        }

        public void Atualizar(Block block)
        {
            _context.Blocks.Update(block);
            _context.SaveChanges();
        }

        public void Remover(Block block)
        {
            _context.Blocks.Remove(block);
            _context.SaveChanges();
        }

        public Block ObterPorId(Guid id)
        {
            return _context.Blocks.Find(id);
        }

        public Block ObterUltimoBloco()
        {
            return _context.Blocks.OrderByDescending(b => b.Timestamp).FirstOrDefault() ?? throw new InvalidOperationException("Block not found");
        }

    }
}
