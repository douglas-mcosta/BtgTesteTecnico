using BTG.Core.DomainObjects;
using BTG.Ecommerce.Application.ViewModel;

namespace BTG.Ecommerce.Application.Queries.Produtos
{
    public interface IProdutoQueries
    {
        Task<PagedResult<ProdutoViewModel>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null);
        Task<ProdutoViewModel> ObterPorIdAsync(Guid id);
    }
}
