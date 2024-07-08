using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Infrastructure.Services
{
    public class DigitalSignatureService
    {
        public string Assinar(string texto, RSAParameters chavePrivada)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(chavePrivada);

            var data = Encoding.UTF8.GetBytes(texto);
            var signedData = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return Convert.ToBase64String(signedData);
        }

        public bool VerificarAssinatura(string texto, string assinatura, RSAParameters chavePublica)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(chavePublica);

            var data = Encoding.UTF8.GetBytes(texto);
            var signedData = Convert.FromBase64String(assinatura);

            return rsa.VerifyData(data, signedData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}
