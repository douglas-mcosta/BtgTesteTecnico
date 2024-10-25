
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
        private readonly EcommerceContext _clienteContext;

        public ProdutoRepository(EcommerceContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public IUnitOfWork UnitOfWork => _clienteContext;

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            var result = await _clienteContext
             .Produtos.AsNoTracking()
             .FirstOrDefaultAsync(x=>x.Id == id);

            return result;
        }

        public async Task<PagedResult<Produto>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null)
        {
            var query = _clienteContext
               .Produtos.AsNoTracking()
               .Where(x =>
                   string.IsNullOrEmpty(nome) ? true : x.Nome.Contains(nome));

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
            _clienteContext.Dispose();
        }

    }
}
