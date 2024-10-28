using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BTG.Relatorio.API.Model;

namespace BTG.Relatorio.API.Data.Mapping
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Produto)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens);

            builder.ToTable("PedidoItens");
        }
    }
}
