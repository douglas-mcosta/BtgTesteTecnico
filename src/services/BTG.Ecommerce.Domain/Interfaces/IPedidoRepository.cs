using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        #region Pedido
        Task<Pedido> ObterPorId(Guid id);
        Task<Pedido> ObterUltimoPedidoPorClienteId(Guid clienteId);
        Task<IEnumerable<Pedido>> ObterListaPorClientId(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        #endregion

        #region Itens
        Task<PedidoItem> ObterItemPorIdAsync(Guid id);
        void Adicionar(PedidoItem pedidoItem);
        void Remover(PedidoItem pedidoItem);
        void Atualizar(PedidoItem pedidoItem);
        void Atualizar(List<PedidoItem> pedidoItem);
        #endregion
    }
}
