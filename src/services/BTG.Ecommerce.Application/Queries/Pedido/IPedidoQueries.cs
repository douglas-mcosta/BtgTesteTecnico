using BTG.Ecommerce.Application.DTO;

namespace BTG.Ecommerce.Application.Queries.Produtos
{
    public interface IPedidoQueries 
    {
        Task<PedidoDTO> ObterUltimoPedido(Guid clientId);
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clientId);
    }
}
