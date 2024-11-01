﻿using BTG.Core.Mediator;
using BTG.Ecommerce.Application.Commands.Pedidos;
using BTG.Ecommerce.Application.Queries.Pedidos;
using BTG.WebAPI.Core.Controllers;
using BTG.WebAPI.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTG.Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/pedido")]
    public class PedidoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAspNetUser _user;
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IMediatorHandler mediatorHandler, IAspNetUser user, IPedidoQueries pedidoQueries)
        {
            _mediatorHandler = mediatorHandler;
            _user = user;
            _pedidoQueries = pedidoQueries;
        }

        [HttpGet]
        public async Task<IActionResult> ObterUltimoPedido()
        {
            var result = await _pedidoQueries.ObterUltimoPedidoAsync(_user.GetUserId());
            return CustomResponse(result);
        }

        [HttpGet("meus-pedidos")]
        public async Task<IActionResult> ObterMeusPedidos()
        {
            var result = await _pedidoQueries.ObterListaPorClienteIdAsync(_user.GetUserId());
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedidoPorId(Guid id)
        {
            var result = await _pedidoQueries.ObterPorIdAsync(id);
            return CustomResponse(result);
        }

        [HttpPost("{produtoId}")]
        public async Task<IActionResult> AdicionarItemPedido(Guid produtoId)
        {
            var usuarioId = _user.GetUserId();
            var commad = new AdicionarItemPedidoCommand(produtoId, _user.GetUserId());

            var result = await _mediatorHandler.SendCommand(commad);
            return CustomResponse(result);
        }

        [HttpPut("processar/{pedidoId}")]
        public async Task<IActionResult> ProcessarPedidoPedido(Guid pedidoId)
        {
            var usuarioId = _user.GetUserId();
            var commad = new ProcessarPedidoCommand(pedidoId, _user.GetUserId());

            var result = await _mediatorHandler.SendCommand(commad);
            return CustomResponse(result);
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult>RemoverItemPedido(Guid itemId)
        {
            var usuarioId = _user.GetUserId();
            var commad = new RemoverItemPedidoCommand(itemId, _user.GetUserId());

            var result = await _mediatorHandler.SendCommand(commad);
            return CustomResponse(result);
        }

    }
}
