using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterListaPorClientId(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
    }
}
