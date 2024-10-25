using BTG.Core.Mediator;
using BTG.Ecommerce.Application.Commands.Pedidos;
using BTG.Ecommerce.Application.Queries.Pedidos;
using BTG.WebAPI.Core.Controllers;
using BTG.WebAPI.Core.User;
using Microsoft.AspNetCore.Mvc;

namespace BTG.Ecommerce.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
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

        [HttpPost("{produtoId}")]
        public async Task<IActionResult> AdicionarItemPedido(Guid produtoId)
        {
            var usuarioId = _user.GetUserId();
            var commad = new AdicionarItemPedidoCommand(produtoId, _user.GetUserId());

            var result = await _mediatorHandler.SendCommand(commad);
            return CustomResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterUltimoPedido()
        {
            var result = _pedidoQueries.ObterUltimoPedido(_user.GetUserId());
            return CustomResponse(result);
        }
    }
}
