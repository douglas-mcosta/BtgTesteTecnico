using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        #region Pedido
        Task<Pedido> ObterPorIdAsync(Guid id);
        Task<Pedido> ObterUltimoPedidoPorClienteIdAsync(Guid clienteId);
        Task<IEnumerable<Pedido>> ObterListaPorClientIdAsync(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        #endregion

        #region Itens
        Task<PedidoItem> ObterItemPorIdAsyncAsync(Guid id);
        void Adicionar(PedidoItem pedidoItem);
        void Remover(PedidoItem pedidoItem);
        void Atualizar(PedidoItem pedidoItem);
        void Atualizar(List<PedidoItem> pedidoItem);
        #endregion
    }
}
