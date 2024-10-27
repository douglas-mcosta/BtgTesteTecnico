using BTG.Ecommerce.Application.ViewModel;

namespace BTG.Ecommerce.Application.Queries.Pedidos
{
    public interface IPedidoQueries
    {
        Task<PedidoViewModel> ObterPorIdAsync(Guid id);
        Task<PedidoViewModel> ObterUltimoPedidoAsync(Guid clientId);
        Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteIdAsync(Guid clientId);
    }
}
