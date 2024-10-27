using BTG.Ecommerce.Application.ViewModel;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Application.Queries.Pedidos
{
    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteId(Guid clientId)
        {
            var pedido = await _pedidoRepository.ObterListaPorClientId(clientId);
            var pedidoVw = pedido.Select(ParaPedidoViewModel); ;
            return pedidoVw;
        }

        public async Task<PedidoViewModel> ObterUltimoPedido(Guid clientId)
        {
            var pedido = await _pedidoRepository.ObterUltimoPedidoPorClienteId(clientId);
            var pedidoVw = ParaPedidoViewModel(pedido);
            return pedidoVw;
        }

        public static PedidoViewModel ParaPedidoViewModel(Pedido pedido)
        {
            if (pedido is null) return new PedidoViewModel();
            var pedidoVw = new PedidoViewModel
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                Codigo = pedido.Codigo,
                Status = (int)pedido.PedidoStatus,
                Data = pedido.DataCadastro,
                ValorTotal = pedido.ValorTotal,
                Itens = new List<PedidoItemViewModel>(),
                Endereco = new EnderecoViewModel()
            };

            foreach (var item in pedido.PedidoItems)
            {
                pedidoVw.Itens.Add(
                    new PedidoItemViewModel
                    {
                        Id = item.Id,
                        ProdutoId = item.ProdutoId,
                        PedidoId = item.PedidoId,
                        Nome = item.ProdutoNome,
                        Imagem = item.ProdutoImagem,
                        Quantidade = item.Quantidade,
                        Valor = item.ValorUnitario,
                        ValorTotal = item.CalcularValor()
                    }
                );
            }

            return pedidoVw;
        }
    }
}
