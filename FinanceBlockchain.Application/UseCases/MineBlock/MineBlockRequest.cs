using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Application.UseCases.MineBlock
{
    public class MineBlockRequest
    {
        public string HashBlocoAnterior { get; set; }
        public List<Transaction> ListaTransacoes { get; set; }
        public int Nonce { get; set; }
    }
}
