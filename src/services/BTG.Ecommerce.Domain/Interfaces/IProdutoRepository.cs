using BTG.Core.DomainObjects;
using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<PagedResult<Produto>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null);
        Task<Produto> ObterPorIdAsync(Guid id);
    }
}
