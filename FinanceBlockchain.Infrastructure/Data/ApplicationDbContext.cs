using FinanceBlockchain.Domain.Entities;
using FinanceBlockchain.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FinanceBlockchain.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Block> Blocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new BlockMap());
        }
    }
}
