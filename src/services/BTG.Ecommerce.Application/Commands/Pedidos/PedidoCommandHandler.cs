using BTG.Core.Enums;
using BTG.Core.Messages;
using BTG.Ecommerce.Application.Events.Pedidos;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace BTG.Ecommerce.Application.Commands.Pedidos
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarItemPedidoCommand, ValidationResult>,
        IRequestHandler<RemoverItemPedidoCommand, ValidationResult>,
        IRequestHandler<ProcessarPedidoCommand, ValidationResult>
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
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

            if (pedido is null || !pedido.PedidoEstaAberto())
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

        public async Task<ValidationResult> Handle(RemoverItemPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var pedido = await _pedidoRepository.ObterUltimoPedidoPorClienteId(request.ClienteId);
            var item = await _pedidoRepository.ObterItemPorIdAsync(request.ItemId);

            if (pedido is null)
            {
                AdicionarErro("Pedido invalido");
                return ValidationResult;
            }

            if (!pedido.PedidoEstaAberto())
            {
                AdicionarErro("Não é permitido remover um item de um pedido com pagamento ou cancelado.");
                return ValidationResult;
            }

            if (item is null)
            {
                AdicionarErro("Item invalido");
                return ValidationResult;
            }

            pedido.RemoverItemPedido(item);
            _pedidoRepository.Atualizar(pedido);
            _pedidoRepository.Remover(item);

            return await SaveChanges(_pedidoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ProcessarPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var pedido = await _pedidoRepository.ObterUltimoPedidoPorClienteId(request.ClienteId);
            var cliente = await _clienteRepository.ObterPorIdAsync(request.ClienteId);

            if (pedido is null)
            {
                AdicionarErro("Pedido invalido");
                return ValidationResult;
            }

            if (cliente is null)
            {
                AdicionarErro("Cliente invalido");
                return ValidationResult;
            }

            if (cliente.Id != request.ClienteId)
            {
                AdicionarErro("O pedido não pertence ao cliente");
                return ValidationResult;
            }

            var produtos = await _produtoRepository.ObterPorPedidoIdAsync(pedido.Id);

            ProcessarPedidoSemEstoque(pedido, produtos);
            if(pedido.PedidoStatus == PedidoStatus.CanceladoFaltaEstoque) return await SaveChanges(_pedidoRepository.UnitOfWork);

            ProcessarPedidoComEstoque(pedido, produtos);
            _pedidoRepository.Atualizar(pedido);

            pedido.AdicionarEvento(new PedidoProcessadoEvent(request.ClienteId, request.PedidoId,pedido.Codigo, pedido.PedidoItems));
            return await SaveChanges(_pedidoRepository.UnitOfWork);
        }

        private void ProcessarPedidoSemEstoque(Pedido pedido, IEnumerable<Produto> produtos)
        {
            foreach (var item in pedido.PedidoItems)
            {
                var produto = produtos?.FirstOrDefault(x => x.Id == item.ProdutoId);
                if (!produto.EstaDiponivel(item.Quantidade))
                {
                    pedido.CancelarPedidoFaltaEstoque();
                    pedido.ProcessarPedido();
                    _pedidoRepository.Atualizar(pedido);
                    break;

                }
            }
        }

        private void ProcessarPedidoComEstoque(Pedido pedido, IEnumerable<Produto> produtos)
        {
            foreach (var item in pedido.PedidoItems)
            {
                var produto = produtos.FirstOrDefault(x => x.Id == item.ProdutoId);
                produto?.RetirarEstoque(item.Quantidade);
            }
            pedido.ProcessarPagamento();
            pedido.ProcessarPedido();
            _produtoRepository.Atualizar(produtos);
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
