using FinanceBlockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBlockchain.Infrastructure.Data.Mappings
{
    public class BlockMap : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.HasKey(b => b.ID);
            builder.Property(b => b.HashBlocoAnterior).IsRequired();
            builder.Property(b => b.HashBlocoAtual).IsRequired();
            builder.Property(b => b.Timestamp).IsRequired();
            builder.Property(b => b.Nonce).IsRequired();
            builder.HasMany(b => b.ListaTransacoes).WithOne().HasForeignKey(t => t.ID);
        }
    }
}
