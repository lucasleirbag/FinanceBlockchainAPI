using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Domain.Repositories
{
    public interface ITransactionRepository
    {
        void Adicionar(Transaction transaction);
        void Atualizar(Transaction transaction);
        void Remover(Transaction transaction);
        Transaction ObterPorId(Guid id);
        IEnumerable<Transaction> ObterPorRemetente(string remetente);
        IEnumerable<Transaction> ObterPorDestinatario(string destinatario);
    }
}
