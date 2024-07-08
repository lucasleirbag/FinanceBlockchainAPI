using FinanceBlockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBlockchain.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.HashSenha).IsRequired().HasMaxLength(256);
            builder.Property(u => u.ChavePublica).IsRequired();
            builder.Property(u => u.ChavePrivada).IsRequired();
        }
    }
}
