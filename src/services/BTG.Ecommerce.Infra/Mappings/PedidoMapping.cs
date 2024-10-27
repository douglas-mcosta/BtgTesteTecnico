using BTG.Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTG.Ecommerce.Infra.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR SequenciaCodigoPedido");

            builder.HasMany(p => p.PedidoItems)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.PedidoId);

            builder.HasOne(p=>p.Cliente)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(i => i.ClienteId);

            builder.ToTable("Pedidos");
        }
    }
}
