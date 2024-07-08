using FinanceBlockchain.Domain.Entities;
using Xunit;

namespace FinanceBlockchain.Tests.Entities
{
    public class BlockTests
    {
        [Fact]
        public void CalcularHash_DeveRetornarHashValido()
        {
            var bloco = new Block
            {
                HashBlocoAnterior = "hash_anterior",
                ListaTransacoes = new List<Transaction>
                {
                    new Transaction { HashTransacao = "hash_transacao_1" },
                    new Transaction { HashTransacao = "hash_transacao_2" }
                },
                Timestamp = DateTime.Now,
                Nonce = 0
            };

            var hash = bloco.CalcularHash();

            Assert.NotEmpty(hash);
        }

        [Fact]
        public void ValidarBloco_DeveRetornarVerdadeiroParaBlocoValido()
        {
            var bloco = new Block
            {
                HashBlocoAnterior = "hash_anterior",
                ListaTransacoes = new List<Transaction>(),
                Timestamp = DateTime.Now,
                Nonce = 0
            };

            var resultado = bloco.ValidarBloco();

            Assert.True(resultado);
        }
    }
}
