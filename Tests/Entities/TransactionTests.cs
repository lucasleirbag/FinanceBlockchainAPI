using System;
using System.Security.Cryptography;
using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Tests.Utils;
using Xunit;

namespace FinanceBlockchain.Tests.Entities
{
    public class TransactionTests
    {
        private string chavePrivada;

        public TransactionTests()
        {
            chavePrivada = RsaKeyGenerator.GeneratePrivateKey();
        }

        [Fact]
        public void AssinarTransacao_DeveGerarAssinaturaValida()
        {
            var transacao = new Transaction
            {
                Valor = 100m,
                Remetente = "chave_publica_remetente",
                Destinatario = "chave_publica_destinatario"
            };

            transacao.AssinarTransacao(chavePrivada);

            Assert.NotNull(transacao.AssinaturaDigital);
        }
    }
}
