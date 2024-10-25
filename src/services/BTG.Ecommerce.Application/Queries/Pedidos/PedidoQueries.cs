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
                PedidoItems = new List<PedidoItemViewModel>(),
                Endereco = new EnderecoViewModel()
            };

            foreach (var item in pedido.PedidoItems)
            {
                pedidoVw.PedidoItems.Add(
                    new PedidoItemViewModel
                    {
                        Nome = item.ProdutoNome,
                        Imagem = item.ProdutoImagem,
                        Quantidade = item.Quantidade,
                        ProdutoId = item.ProdutoId,
                        Valor = item.ValorUnitario,
                        PedidoId = item.PedidoId
                    }
                );
            }

            if (pedido.Endereco is not null)
                pedidoVw.Endereco = new EnderecoViewModel
                {
                    Logradouro = pedido.Endereco.Logradouro,
                    Numero = pedido.Endereco.Numero,
                    Complemento = pedido.Endereco.Complemento,
                    Bairro = pedido.Endereco.Bairro,
                    Cep = pedido.Endereco.Cep,
                    Cidade = pedido.Endereco.Cidade,
                    Estado = pedido.Endereco.Estado
                };

            return pedidoVw;
        }
    }
}
