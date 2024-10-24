using BTG.Core.DomainObjects;

namespace BTG.Ecommerce.Domain.Models
{
    public class Cliente : Entity
    {
        public Cliente()
        {

        }

        public Cliente(Guid id, string nome, string email, string cpf) : this()
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public IEnumerable<Pedido> Pedidos { get; private set; }
    }
}
