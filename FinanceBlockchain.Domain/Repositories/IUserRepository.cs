using FinanceBlockchain.Domain.Entities;

namespace FinanceBlockchain.Domain.Repositories
{
    public interface IUserRepository
    {
        void Adicionar(User user);
        void Atualizar(User user);
        void Remover(User user);
        User ObterPorId(Guid id);
        User ObterPorEmail(string email);
    }
}
