using BTG.Clientes.Domain.Models;
using BTG.Core.DomainObjects.Data;

namespace BTG.Clientes.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
