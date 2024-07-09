using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FinanceBlockchain.Infrastructure.Services
{
    public class EncryptionService
    {
        private const int KeySize = 32; // 256 bits (32 bytes)
        private const int IvSize = 12; // 96 bits (12 bytes) para GCM
        private const int TagSize = 16; // 128 bits (16 bytes) para GCM
        private const int SaltSize = 16; // 128 bits (16 bytes)
        private const int Iterations = 10000; // Número de iterações para derivar a chave

        public string Criptografar(string texto, string senha)
        {
            if (senha.Length < 32)
            {
                throw new ArgumentException("A senha deve ter no mínimo 32 caracteres.", nameof(senha));
            }

            var salt = GenerateSalt();
            var key = DeriveKey(senha, salt);
            var iv = GenerateIV();
            var plaintextBytes = Encoding.UTF8.GetBytes(texto);

            using var aesGcm = new AesGcm(key);
            var ciphertext = new byte[plaintextBytes.Length];
            var tag = new byte[TagSize];

            aesGcm.Encrypt(iv, plaintextBytes, ciphertext, tag);

            using var msEncrypt = new MemoryStream();
            msEncrypt.Write(salt, 0, salt.Length);
            msEncrypt.Write(iv, 0, iv.Length);
            msEncrypt.Write(tag, 0, tag.Length);
            msEncrypt.Write(ciphertext, 0, ciphertext.Length);

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Descriptografar(string textoCriptografado, string senha)
        {
            if (senha.Length < 32)
            {
                throw new ArgumentException("A senha deve ter no mínimo 32 caracteres.", nameof(senha));
            }

            try
            {
                var fullCipher = Convert.FromBase64String(textoCriptografado);

                using var msDecrypt = new MemoryStream(fullCipher);
                var salt = new byte[SaltSize];
                var iv = new byte[IvSize];
                var tag = new byte[TagSize];

                if (msDecrypt.Read(salt, 0, salt.Length) != salt.Length)
                {
                    throw new CryptographicException("Salt inválido.");
                }

                if (msDecrypt.Read(iv, 0, iv.Length) != iv.Length)
                {
                    throw new CryptographicException("IV inválido.");
                }

                if (msDecrypt.Read(tag, 0, tag.Length) != tag.Length)
                {
                    throw new CryptographicException("Tag inválida.");
                }

                var key = DeriveKey(senha, salt);
                var ciphertextBytes = new byte[msDecrypt.Length - salt.Length - iv.Length - tag.Length];
                msDecrypt.Read(ciphertextBytes, 0, ciphertextBytes.Length);

                var plaintextBytes = new byte[ciphertextBytes.Length];
                using var aesGcm = new AesGcm(key);
                aesGcm.Decrypt(iv, ciphertextBytes, tag, plaintextBytes);

                return Encoding.UTF8.GetString(plaintextBytes);
            }
            catch (Exception ex) when (ex is FormatException || ex is CryptographicException)
            {
                throw new CryptographicException("Texto criptografado inválido ou erro ao descriptografar os dados.", ex);
            }
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[SaltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }

        private byte[] GenerateIV()
        {
            var iv = new byte[IvSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(iv);
            return iv;
        }

        private byte[] DeriveKey(string senha, byte[] salt)
        {
            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(senha, salt, Iterations, HashAlgorithmName.SHA256);
            return rfc2898DeriveBytes.GetBytes(KeySize);
        }
    }
}
