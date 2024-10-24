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

            builder.OwnsOne(p => p.Endereco, e =>
            {
                e.Property(pe => pe.Logradouro)
                    .HasColumnName("Logradouro");

                e.Property(pe => pe.Numero)
                    .HasColumnName("Numero");

                e.Property(pe => pe.Complemento)
                    .HasColumnName("Complemento");

                e.Property(pe => pe.Bairro)
                    .HasColumnName("Bairro");

                e.Property(pe => pe.Cep)
                    .HasColumnName("Cep");

                e.Property(pe => pe.Cidade)
                    .HasColumnName("Cidade");

                e.Property(pe => pe.Estado)
                    .HasColumnName("Estado");
            });

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
