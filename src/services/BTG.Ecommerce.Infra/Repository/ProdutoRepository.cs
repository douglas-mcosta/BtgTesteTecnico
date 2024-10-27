
using BTG.Core.DomainObjects;
using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using BTG.Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BTG.Ecommerce.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EcommerceContext _context;

        public ProdutoRepository(EcommerceContext clienteContext)
        {
            _context = clienteContext;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            var result = await _context
             .Produtos.AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public async Task<PagedResult<Produto>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null)
        {
            var query = _context
               .Produtos.AsNoTracking()
               .Where(x =>
                   string.IsNullOrEmpty(nome) ? true : x.Nome.Contains(nome))
               .OrderBy(x=>x.Nome);

            var totalResults = query.Count();

            var resultadoPaginado = query
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .OrderByDescending(x => x.DataCadastro);

            return new PagedResult<Produto>
            {
                Nome = nome,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = totalResults,
                List = resultadoPaginado.AsEnumerable()
            };
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Produto>> ObterPorPedidoIdAsync(Guid pedidoId)
        {
            var result = await (from p in _context.Produtos
                                join pi in _context.PedidoItens on p.Id equals pi.ProdutoId
                                where pi.PedidoId == pedidoId
                                select p).ToListAsync();
            return result;
        }

        public void Atualizar(IEnumerable<Produto> produtos)
        {
            _context.Produtos.UpdateRange(produtos);
        }
    }
}
