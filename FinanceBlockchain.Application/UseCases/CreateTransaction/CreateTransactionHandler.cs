using FinanceBlockchain.Application.Interfaces;

namespace FinanceBlockchain.Application.UseCases.CreateTransaction
{
    public class CreateTransactionHandler
    {
        private readonly ITransactionService _transactionService;

        public CreateTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public CreateTransactionResponse Handle(CreateTransactionRequest request)
        {
            return _transactionService.CreateTransaction(request);
        }
    }
}
