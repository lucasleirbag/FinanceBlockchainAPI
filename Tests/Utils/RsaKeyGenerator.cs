using System;
using System.Security.Cryptography;

namespace FinanceBlockchain.Tests.Utils
{
    public class RsaKeyGenerator
    {
        public static string GeneratePrivateKey()
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            return rsa.ToXmlString(true);
        }
    }
}

