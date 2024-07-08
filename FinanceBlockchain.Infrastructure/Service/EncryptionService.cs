using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Infrastructure.Services
{
    public class EncryptionService
    {
        public string Criptografar(string texto, string chave)
        {
            using var aesAlg = Aes.Create();
            var key = Encoding.UTF8.GetBytes(chave);
            var iv = aesAlg.IV;

            using var encryptor = aesAlg.CreateEncryptor(key, iv);
            using var msEncrypt = new MemoryStream();
            msEncrypt.Write(iv, 0, iv.Length);
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            swEncrypt.Write(texto);

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Descriptografar(string textoCriptografado, string chave)
        {
            var fullCipher = Convert.FromBase64String(textoCriptografado);

            using var aesAlg = Aes.Create();
            var iv = new byte[aesAlg.BlockSize / 8];
            var cipherText = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

            var key = Encoding.UTF8.GetBytes(chave);

            using var decryptor = aesAlg.CreateDecryptor(key, iv);
            using var msDecrypt = new MemoryStream(cipherText);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
