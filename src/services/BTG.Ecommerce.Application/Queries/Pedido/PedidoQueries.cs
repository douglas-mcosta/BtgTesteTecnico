using BTG.Ecommerce.Application.DTO;

namespace BTG.Ecommerce.Application.Queries.Produtos
{
    public class PedidoQueries : IPedidoQueries
    {
        public Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDTO> ObterUltimoPedido(Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}
