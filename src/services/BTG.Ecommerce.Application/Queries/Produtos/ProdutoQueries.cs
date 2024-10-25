using BTG.Core.DomainObjects;
using BTG.Ecommerce.Application.DTO;
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

        public async Task<ProdutoDTO> ObterPorIdAsync(Guid id)
        {
            var domain = await _produtoRepository.ObterPorIdAsync(id);

            return ParaProdutoDTO(domain);
            
        }

        public async Task<PagedResult<ProdutoDTO>> ObterTodosAsync(int pageSize, int pageIndex, string nome = null)
        {
            var domain = await _produtoRepository.ObterTodosAsync(pageSize, pageIndex, nome);

            return new PagedResult<ProdutoDTO> {
               PageIndex = pageIndex,
               PageSize = pageSize,
               Query = domain.Query,
               TotalResults = domain.TotalResults,
               List = domain.List.Select(ParaProdutoDTO)
            };
        }

        public static ProdutoDTO ParaProdutoDTO(Produto produto)
        {
            return new ProdutoDTO
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Valor = produto.Valor
            };
        }

    }
}
