using BTG.Core.DomainObjects.Data;
using BTG.Relatorio.API.Model;

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

        public void Dispose()
        {
            _context?.Dispose();
        }

        public Task<IEnumerable<Pedido>> ObterListaPorClientId(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
