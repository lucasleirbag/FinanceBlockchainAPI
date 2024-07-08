namespace FinanceBlockchain.Application.UseCases.CreateTransaction
{
    public class CreateTransactionResponse
    {
        public bool Success { get; set; }
        public Guid TransactionId { get; set; }
    }
}
