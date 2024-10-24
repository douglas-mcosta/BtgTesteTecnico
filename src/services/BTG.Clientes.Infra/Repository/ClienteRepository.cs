using BTG.Clientes.Domain.Interfaces;
using BTG.Clientes.Domain.Models;
using BTG.Clientes.Infra.Context;
using BTG.Core.DomainObjects.Data;
using Microsoft.EntityFrameworkCore;

namespace BTG.Clientes.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _clienteContext;

        public ClienteRepository(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public IUnitOfWork UnitOfWork => _clienteContext;

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _clienteContext.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> ObterPorCpf(string cpf)
        {
            return await _clienteContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Cpf.Numero == cpf);
        }

        public void Adicionar(Cliente cliente)
        {
            _clienteContext.Clientes.Add(cliente);
        }


        public void Dispose()
        {
            _clienteContext.Dispose();
        }


    }
}
