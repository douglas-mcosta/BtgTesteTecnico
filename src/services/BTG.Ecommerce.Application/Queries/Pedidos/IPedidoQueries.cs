using BTG.Ecommerce.Application.ViewModel;

namespace BTG.Ecommerce.Application.Queries.Pedidos
{
    public interface IPedidoQueries
    {
        Task<PedidoViewModel> ObterUltimoPedido(Guid clientId);
        Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteId(Guid clientId);
    }
}
