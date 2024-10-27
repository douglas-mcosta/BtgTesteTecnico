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

        #region Pedido
        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public async Task<IEnumerable<Pedido>> ObterListaPorClientIdAsync(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(x => x.Cliente)
                .Include(x => x.PedidoItems)
                .ThenInclude(x => x.Produto)
                .Where(x=> x.ClienteId == clienteId)
                .OrderByDescending(x=>x.Codigo)
                .ToListAsync();
        }

        public async Task<Pedido> ObterPorIdAsync(Guid id)
        {
            return await _context
                .Pedidos
                .Include(x => x.Cliente)
                .Include(x => x.PedidoItems)
                .ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> ObterUltimoPedidoPorClienteIdAsync(Guid clienteId)
        {
            return await _context
                .Pedidos
                .Include(x=>x.Cliente)
                .Include(x => x.PedidoItems)
                .ThenInclude(x => x.Produto)
                .OrderByDescending(x=>x.DataCadastro).FirstOrDefaultAsync(x => x.ClienteId == clienteId);
        }
        #endregion

        #region Item
        public async Task<PedidoItem> ObterItemPorIdAsyncAsync(Guid id)
        {
            return await _context.PedidoItens.Include(x=>x.Produto).FirstOrDefaultAsync(x=>x.Id == id);
        }
        public void Adicionar(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Add(pedidoItem);
        }

        public void Atualizar(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Update(pedidoItem);
        }
        public void Atualizar(List<PedidoItem> pedidoItem)
        {
            _context.PedidoItens.UpdateRange(pedidoItem);
        }

        public void Remover(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Remove(pedidoItem);
        }
        #endregion
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
