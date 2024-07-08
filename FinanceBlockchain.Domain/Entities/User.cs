using System;

namespace FinanceBlockchain.Domain.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashSenha { get; set; } = string.Empty;
        public string ChavePublica { get; set; } = string.Empty;
        public string ChavePrivada { get; set; } = string.Empty; // Deve ser armazenada de forma segura

        public bool ValidarUsuario()
        {
            // Implementar lógica de validação
            return true;
        }

        public bool Autenticar(string senha)
        {
            // Implementar lógica de autenticação
            return true;
        }
    }
}
