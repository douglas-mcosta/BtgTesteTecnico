using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<Pedido> ObterUltimoPedidoPorClienteId(Guid clienteId);
        Task<IEnumerable<Pedido>> ObterListaPorClientId(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Adicionar(PedidoItem pedidoItem);
        void Atualizar(PedidoItem pedidoItem);
        void Atualizar(List<PedidoItem> pedidoItem);
        void Atualizar(Pedido pedido);
    }
}
