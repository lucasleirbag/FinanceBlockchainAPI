using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using Moq;
using System;
using Xunit;

public class BlockRepositoryTests
{
    private readonly Mock<IBlockRepository> _blockRepositoryMock;

    public BlockRepositoryTests()
    {
        _blockRepositoryMock = new Mock<IBlockRepository>();
    }

    [Fact]
    public void Adicionar_DeveAdicionarBloco()
    {
        var bloco = new Block { ID = Guid.NewGuid(), HashBlocoAnterior = "hash_anterior", ListaTransacoes = new List<Transaction>(), Timestamp = DateTime.Now, Nonce = 0 };

        _blockRepositoryMock.Setup(repo => repo.Adicionar(bloco));

        _blockRepositoryMock.Object.Adicionar(bloco);

        _blockRepositoryMock.Verify(repo => repo.Adicionar(It.IsAny<Block>()), Times.Once);
    }

    [Fact]
    public void ObterPorId_DeveRetornarBloco()
    {
        var blocoId = Guid.NewGuid();
        var bloco = new Block { ID = blocoId, HashBlocoAnterior = "hash_anterior", ListaTransacoes = new List<Transaction>(), Timestamp = DateTime.Now, Nonce = 0 };

        _blockRepositoryMock.Setup(repo => repo.ObterPorId(blocoId)).Returns(bloco);

        var resultado = _blockRepositoryMock.Object.ObterPorId(blocoId);

        Assert.Equal(bloco, resultado);
    }
}
