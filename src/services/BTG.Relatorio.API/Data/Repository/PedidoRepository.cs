using BTG.Core.DomainObjects.Data;
using BTG.Relatorio.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BTG.Relatorio.API.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly RelatorioContext _context;
        public PedidoRepository(RelatorioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public async Task<IEnumerable<RelatorioPedidoProcessado>> ObterRelatorioPedidoProcessados()
        {
            var relatorio = await _context.Pedidos
                .Include(x => x.Itens)
                .Select(x => new RelatorioPedidoProcessado
                {
                    CodigoCliente = x.CodigoCliente,
                    NomeCliente = x.NomeCliente,
                    QtdPedidos = x.Itens.Count(),
                    Pedidos = _context.Pedidos.Include(x => x.Itens).Where(p => p.CodigoCliente == x.CodigoCliente).ToList(),
                    ValorTotal = x.Itens.Sum(x => x.Total)
                })
                .ToListAsync();
            return relatorio;

        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
