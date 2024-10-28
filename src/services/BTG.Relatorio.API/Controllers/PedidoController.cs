using BTG.Relatorio.API.Data.Repository;
using BTG.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTG.Relatorio.API.Controllers
{
    [Route("api/relatorio")]
    [Authorize]
    public class PedidoController : MainController
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("pedidos-processados")]
        public async Task<IActionResult> ObterPedidosProcessado()
        {
            var result = await _pedidoRepository.ObterRelatorioPedidoProcessados();
            return CustomResponse(result);
        }

    }
}
