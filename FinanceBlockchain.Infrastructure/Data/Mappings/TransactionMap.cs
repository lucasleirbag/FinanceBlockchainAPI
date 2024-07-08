using FinanceBlockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBlockchain.Infrastructure.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Valor).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(t => t.Data).IsRequired();
            builder.Property(t => t.Remetente).IsRequired();
            builder.Property(t => t.Destinatario).IsRequired();
            builder.Property(t => t.HashTransacao).IsRequired();
            builder.Property(t => t.AssinaturaDigital).IsRequired();
        }
    }
}
