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

        public async Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteIdAsync(Guid clientId)
        {
            var pedido = await _pedidoRepository.ObterListaPorClientIdAsync(clientId);
            var pedidoVw = pedido.Select(ParaPedidoViewModel); ;
            return pedidoVw;
        }

        public async Task<PedidoViewModel> ObterUltimoPedidoAsync(Guid clientId)
        {
            var pedido = await _pedidoRepository.ObterUltimoPedidoPorClienteIdAsync(clientId);
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
                ClienteNome = pedido?.Cliente?.Nome ?? "",
                Codigo = pedido.Codigo,
                Status = (int)pedido.PedidoStatus,
                Data = pedido.DataCadastro,
                ValorTotal = pedido.ValorTotal,
                Itens = new List<PedidoItemViewModel>()
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

        public async Task<PedidoViewModel> ObterPorIdAsync(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);
            var pedidoVw = ParaPedidoViewModel(pedido);
            return pedidoVw; throw new NotImplementedException();
        }
    }
}
