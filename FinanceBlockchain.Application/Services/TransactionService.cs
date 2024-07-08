using FinanceBlockchain.Application.Interfaces;
using FinanceBlockchain.Application.UseCases.CreateTransaction;
using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;

namespace FinanceBlockchain.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public CreateTransactionResponse CreateTransaction(CreateTransactionRequest request)
        {
            var transaction = new Transaction
            {
                ID = Guid.NewGuid(),
                Valor = request.Valor,
                Data = DateTime.Now,
                Remetente = request.Remetente,
                Destinatario = request.Destinatario,
                HashTransacao = request.HashTransacao,
                AssinaturaDigital = request.AssinaturaDigital
            };

            _transactionRepository.Adicionar(transaction);

            return new CreateTransactionResponse { Success = true, TransactionId = transaction.ID };
        }
    }
}
