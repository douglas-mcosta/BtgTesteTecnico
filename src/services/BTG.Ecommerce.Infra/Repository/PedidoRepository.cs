using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using BTG.Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BTG.Ecommerce.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Adicionar(PedidoItem pedidoItem)
        {
            _context.PedidoItems.Add(pedidoItem);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public void Atualizar(PedidoItem pedidoItem)
        {
            _context.PedidoItems.Update(pedidoItem);
        }
        public void Atualizar(List<PedidoItem> pedidoItem)
        {
            _context.PedidoItems.UpdateRange(pedidoItem);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Pedido>> ObterListaPorClientId(Guid clienteId)
        {
            return await _context.Pedidos.Include(x => x.PedidoItems).ThenInclude(x => x.Produto).Where(x=> x.ClienteId == clienteId).ToListAsync();
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            return await _context.Pedidos.Include(x => x.PedidoItems).ThenInclude(x => x.Produto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> ObterUltimoPedidoPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos.Include(x => x.PedidoItems).ThenInclude(x => x.Produto).FirstOrDefaultAsync(x => x.ClienteId == clienteId);
        }
    }
}
