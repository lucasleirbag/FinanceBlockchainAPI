namespace FinanceBlockchain.Application.UseCases.CreateUser
{
    public class CreateUserRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string HashSenha { get; set; }
        public string ChavePublica { get; set; }
        public string ChavePrivada { get; set; }
    }
}
