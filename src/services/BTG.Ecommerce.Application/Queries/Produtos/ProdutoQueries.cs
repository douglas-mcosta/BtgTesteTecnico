using BTG.Core.DomainObjects;
using BTG.Ecommerce.Application.ViewModel;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Application.Queries.Produtos
{
    public class ProdutoQueries : IProdutoQueries
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoQueries(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoViewModel> ObterPorIdAsync(Guid id)
        {
            var domain = await _produtoRepository.ObterPorIdAsync(id);

            return ParaProdutoDTO(domain);
            
        }

        public async Task<PagedResult<ProdutoViewModel>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null)
        {
            var domain = await _produtoRepository.ObterTodosAsync(pageSize, pageIndex, nome);

            return new PagedResult<ProdutoViewModel> {
               PageIndex = pageIndex,
               PageSize = pageSize,
               Nome = domain.Nome,
               TotalResults = domain.TotalResults,
               List = domain.List.Select(ParaProdutoDTO)
            };
        }

        public static ProdutoViewModel ParaProdutoDTO(Produto produto)
        {
            return new ProdutoViewModel
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Valor = produto.Valor,
                Imagem = produto.Imagem 
            };
        }

    }
}
