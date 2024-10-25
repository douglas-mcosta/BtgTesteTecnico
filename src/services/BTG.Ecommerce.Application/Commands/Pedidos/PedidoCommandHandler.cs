using BTG.Core.Messages;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace BTG.Ecommerce.Application.Commands.Pedidos
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarItemPedidoCommand, ValidationResult>
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarItemPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var pedido = await _pedidoRepository.ObterUltimoPedidoPorClienteId(request.ClienteId);
            var produto = await _produtoRepository.ObterPorIdAsync(request.ProdutoId);

            if (produto is null)
            {
                AdicionarErro("Produto invalido");
                return ValidationResult;
            }

            if (pedido is null)
            {
                var itemPedido = new PedidoItem(produto.Id, produto.Nome, 1, produto.Valor, produto.Imagem);
                var novoPedido = new Pedido(request.ClienteId);

                novoPedido.AddItemPedido(itemPedido);
                _pedidoRepository.Adicionar(novoPedido);
                return await SaveChanges(_pedidoRepository.UnitOfWork);
            }

            if (pedido.PedidoEstaAberto())
            {
                AtualizarItemsDoPedido(pedido, produto);
                _pedidoRepository.Atualizar(pedido);
            }

            return await SaveChanges(_pedidoRepository.UnitOfWork);
        }

        private void AtualizarItemsDoPedido(Pedido pedido, Produto produto)
        {
            var itemPedido = new PedidoItem(pedido.Id, produto.Id, produto.Nome, 1, produto.Valor, produto.Imagem);

            if (pedido.ExisteItem(itemPedido))
            {
                pedido.AddItemPedido(itemPedido);
                _pedidoRepository.Atualizar(pedido.PedidoItems);
            }
            else
            {
                pedido.AddItemPedido(itemPedido);
                _pedidoRepository.Adicionar(itemPedido);
            }
        }
    }
}
