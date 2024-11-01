﻿using BTG.Core.DomainObjects;
using BTG.Core.Mediator;
using BTG.Ecommerce.Application.Queries.Produtos;
using BTG.Ecommerce.Application.ViewModel;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.WebAPI.Core.Controllers;
using BTG.WebAPI.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTG.Ecommerce.API.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClienteRepository _clienteRepository;
        private readonly IAspNetUser _user;
        private readonly IProdutoQueries _produtoQueries;

        public ProdutoController(IMediatorHandler mediatorHandler, IClienteRepository clienteRepository, IAspNetUser user, IProdutoQueries produtoQueries)
        {
            _mediatorHandler = mediatorHandler;
            _clienteRepository = clienteRepository;
            _user = user;
            _produtoQueries = produtoQueries;
        }

        [HttpGet]
        public async Task<PagedResult<ProdutoViewModel>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string nome = null)
        {
            return await _produtoQueries.ObterTodosAsync(ps, page, nome);
        }

        [HttpGet("{id}")]
        public async Task<ProdutoViewModel> ProdutoDetalhe(Guid id)
        {
            return await _produtoQueries.ObterPorIdAsync(id);
        }

    }
}
