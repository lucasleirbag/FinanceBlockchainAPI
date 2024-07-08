using FinanceBlockchain.Domain.Entities;
using Xunit;

namespace FinanceBlockchain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void ValidarUsuario_DeveRetornarVerdadeiroParaUsuarioValido()
        {
            var usuario = new User
            {
                Nome = "Teste",
                Email = "teste@example.com",
                HashSenha = "hash_senha"
            };

            var resultado = usuario.ValidarUsuario();

            Assert.True(resultado);
        }

        [Fact]
        public void Autenticar_DeveRetornarVerdadeiroParaSenhaCorreta()
        {
            var usuario = new User
            {
                HashSenha = "hash_senha"
            };

            var resultado = usuario.Autenticar("senha");

            Assert.True(resultado);
        }
    }
}
