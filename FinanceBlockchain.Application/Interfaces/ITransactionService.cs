using FinanceBlockchain.Application.UseCases.CreateTransaction;

namespace FinanceBlockchain.Application.Interfaces
{
    public interface ITransactionService
    {
        CreateTransactionResponse CreateTransaction(CreateTransactionRequest request);
    }
}
