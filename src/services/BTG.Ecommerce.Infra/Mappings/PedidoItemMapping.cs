using BTG.Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BTG.Ecommerce.Infra.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.PedidoItems);

            builder.HasOne(i => i.Produto)
               .WithMany(p => p.PedidoItens);

            builder.ToTable("PedidoItems");
        }
    }
}
