using BTG.Core.DomainObjects.Data;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using BTG.Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BTG.Ecommerce.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EcommerceContext _clienteContext;

        public ClienteRepository(EcommerceContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public IUnitOfWork UnitOfWork => _clienteContext;

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _clienteContext.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> ObterPorCpfAsync(string cpf)
        {
            return await _clienteContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Cpf.Numero == cpf);
        }

        public void Adicionar(Cliente cliente)
        {
            _clienteContext.Clientes.Add(cliente);
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return await _clienteContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
        }
        public void Dispose()
        {
            _clienteContext.Dispose();
        }
    }
}
