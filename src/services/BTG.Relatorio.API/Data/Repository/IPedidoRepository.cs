using BTG.Core.DomainObjects.Data;
using BTG.Relatorio.API.Model;

namespace BTG.Relatorio.API.Data.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<RelatorioPedidoProcessado>> ObterRelatorioPedidoProcessados();
        void Adicionar(Pedido pedido);
    }
}
