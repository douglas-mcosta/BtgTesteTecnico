using BTG.Core.DomainObjects;
using BTG.Ecommerce.Application.DTO;

namespace BTG.Ecommerce.Application.Queries.Produtos
{
    public interface IProdutoQueries
    {
        Task<PagedResult<ProdutoDTO>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null);
        Task<ProdutoDTO> ObterPorIdAsync(Guid id);
    }
}
