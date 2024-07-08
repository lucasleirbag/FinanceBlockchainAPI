using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Domain.Repositories;
using FinanceBlockchain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceBlockchain.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Atualizar(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        public void Remover(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        public Transaction ObterPorId(Guid id)
        {
            return _context.Transactions.Find(id);
        }

        public IEnumerable<Transaction> ObterPorRemetente(string remetente)
        {
            return _context.Transactions.Where(t => t.Remetente == remetente).ToList();
        }

        public IEnumerable<Transaction> ObterPorDestinatario(string destinatario)
        {
            return _context.Transactions.Where(t => t.Destinatario == destinatario).ToList();
        }
    }
}
