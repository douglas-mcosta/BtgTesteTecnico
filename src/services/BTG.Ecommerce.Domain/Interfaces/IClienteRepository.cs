﻿using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}