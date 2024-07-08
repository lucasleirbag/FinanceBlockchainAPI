using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Infrastructure.Services
{
    public class HashingService
    {
        public string GerarHash(string texto)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(texto);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
