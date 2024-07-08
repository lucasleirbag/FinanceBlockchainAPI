using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

public class TransactionRepositoryTests
{
    private readonly Mock<ITransactionRepository> _transactionRepositoryMock;

    public TransactionRepositoryTests()
    {
        _transactionRepositoryMock = new Mock<ITransactionRepository>();
    }

    [Fact]
    public void Adicionar_DeveAdicionarTransacao()
    {
        var transacao = new Transaction { ID = Guid.NewGuid(), Valor = 100m, Remetente = "chave_publica_remetente", Destinatario = "chave_publica_destinatario" };

        _transactionRepositoryMock.Setup(repo => repo.Adicionar(transacao));

        _transactionRepositoryMock.Object.Adicionar(transacao);

        _transactionRepositoryMock.Verify(repo => repo.Adicionar(It.IsAny<Transaction>()), Times.Once);
    }

    [Fact]
    public void ObterPorId_DeveRetornarTransacao()
    {
        var transacaoId = Guid.NewGuid();
        var transacao = new Transaction { ID = transacaoId, Valor = 100m, Remetente = "chave_publica_remetente", Destinatario = "chave_publica_destinatario" };

        _transactionRepositoryMock.Setup(repo => repo.ObterPorId(transacaoId)).Returns(transacao);

        var resultado = _transactionRepositoryMock.Object.ObterPorId(transacaoId);

        Assert.Equal(transacao, resultado);
    }
}
