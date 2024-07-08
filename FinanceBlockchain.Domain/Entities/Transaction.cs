using System;
using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Domain.Entities
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Remetente { get; set; } = string.Empty; // Chave pública do remetente
        public string Destinatario { get; set; } = string.Empty; // Chave pública do destinatário
        public string HashTransacao { get; set; } = string.Empty;
        public string AssinaturaDigital { get; set; } = string.Empty;

        public bool ValidarTransacao()
        {
            // Implementar lógica de validação
            return true;
        }

        public void AssinarTransacao(string chavePrivada)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(chavePrivada);

            var hash = SHA256.HashData(Encoding.UTF8.GetBytes($"{Remetente}{Destinatario}{Valor}{Data}"));
            var signature = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            AssinaturaDigital = Convert.ToBase64String(signature);
        }
    }
}
