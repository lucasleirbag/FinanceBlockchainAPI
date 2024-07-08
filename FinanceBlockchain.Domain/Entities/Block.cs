using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Domain.Entities
{
    public class Block
    {
        public Guid ID { get; set; }
        public string HashBlocoAnterior { get; set; } = string.Empty;
        public string HashBlocoAtual { get; set; } = string.Empty;
        public List<Transaction> ListaTransacoes { get; set; } = new();
        public DateTime Timestamp { get; set; }
        public int Nonce { get; set; } // Usado para proof-of-work

        public string CalcularHash()
        {
            using var sha256 = SHA256.Create();
            var rawData = $"{HashBlocoAnterior}{Timestamp}{Nonce}{string.Join("", ListaTransacoes.Select(t => t.HashTransacao))}";
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Convert.ToBase64String(bytes);
        }

        public bool ValidarBloco()
        {
            // Implementar lógica de validação
            return true;
        }
    }
}
