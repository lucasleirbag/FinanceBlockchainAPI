using FinanceBlockchain.API.Controllers;
using FinanceBlockchain.Application.UseCases.CreateTransaction;
using FinanceBlockchain.Application.Interfaces;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBlockchain.Tests.ControllersTests
{
    public class TransactionsControllerTests
    {
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly TransactionsController _controller;

        public TransactionsControllerTests()
        {
            _transactionServiceMock = new Mock<ITransactionService>();
            var createTransactionHandler = new CreateTransactionHandler(_transactionServiceMock.Object);

            _controller = new TransactionsController(createTransactionHandler);
        }

        [Fact]
        public void Create_DeveRetornarOkResultParaTransacaoValida()
        {
            var request = new CreateTransactionRequest
            {
                Valor = 100m,
                Remetente = "public_key_sender",
                Destinatario = "public_key_receiver",
                HashTransacao = "transaction_hash",
                AssinaturaDigital = "digital_signature"
            };

            _transactionServiceMock.Setup(x => x.CreateTransaction(request)).Returns(new CreateTransactionResponse { Success = true });

            var result = _controller.Create(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Create_DeveRetornarBadRequestParaTransacaoInvalida()
        {
            var request = new CreateTransactionRequest
            {
                Valor = 100m,
                Remetente = "public_key_sender",
                Destinatario = "public_key_receiver",
                HashTransacao = "transaction_hash",
                AssinaturaDigital = "digital_signature"
            };

            _transactionServiceMock.Setup(x => x.CreateTransaction(request)).Returns(new CreateTransactionResponse { Success = false });

            var result = _controller.Create(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
