using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Infrastructure.Services
{
    public class EncryptionService
    {
        private const int KeySize = 256; // 256 bits
        private const int IvSize = 16; // 128 bits
        private const int Iterations = 10000; // Número de iterações para derivar a chave
        private const int SaltSize = 16; // 128 bits

        public string Criptografar(string texto, string senha)
        {
            if (senha.Length < 32)
            {
                throw new ArgumentException("A senha deve ter no mínimo 32 caracteres.", nameof(senha));
            }

            var salt = GenerateSalt();
            var key = DeriveKey(senha, salt);

            using var aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.GenerateIV();
            var iv = aesAlg.IV;

            using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);
            using var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                msEncrypt.Write(salt, 0, salt.Length);
                msEncrypt.Write(iv, 0, iv.Length);
                swEncrypt.Write(texto);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Descriptografar(string textoCriptografado, string senha)
        {
            if (senha.Length < 32)
            {
                throw new ArgumentException("A senha deve ter no mínimo 32 caracteres.", nameof(senha));
            }

            var fullCipher = Convert.FromBase64String(textoCriptografado);

            using var msDecrypt = new MemoryStream(fullCipher);
            var salt = new byte[SaltSize];
            msDecrypt.Read(salt, 0, salt.Length);

            var key = DeriveKey(senha, salt);

            var iv = new byte[IvSize];
            msDecrypt.Read(iv, 0, iv.Length);

            using var aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            using var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);

            return srDecrypt.ReadToEnd();
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        private byte[] DeriveKey(string senha, byte[] salt)
        {
            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(senha, salt, Iterations, HashAlgorithmName.SHA256);
            return rfc2898DeriveBytes.GetBytes(KeySize / 8);
        }
    }
}
