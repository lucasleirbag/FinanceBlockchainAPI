using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using Moq;
using System;
using Xunit;

public class UserRepositoryTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public UserRepositoryTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    [Fact]
    public void Adicionar_DeveAdicionarUsuario()
    {
        var usuario = new User { ID = Guid.NewGuid(), Nome = "Teste", Email = "teste@example.com" };

        _userRepositoryMock.Setup(repo => repo.Adicionar(usuario));

        _userRepositoryMock.Object.Adicionar(usuario);

        _userRepositoryMock.Verify(repo => repo.Adicionar(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void ObterPorId_DeveRetornarUsuario()
    {
        var usuarioId = Guid.NewGuid();
        var usuario = new User { ID = usuarioId, Nome = "Teste", Email = "teste@example.com" };

        _userRepositoryMock.Setup(repo => repo.ObterPorId(usuarioId)).Returns(usuario);

        var resultado = _userRepositoryMock.Object.ObterPorId(usuarioId);

        Assert.Equal(usuario, resultado);
    }
}
