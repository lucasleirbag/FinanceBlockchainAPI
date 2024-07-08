using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using FinanceBlockchain.Infrastructure.Data;

namespace FinanceBlockchain.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Atualizar(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Remover(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User ObterPorId(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User ObterPorEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email) ?? throw new InvalidOperationException("User not found");
        }
    }
}
