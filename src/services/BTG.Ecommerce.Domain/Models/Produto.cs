using BTG.Core.DomainObjects;

namespace BTG.Ecommerce.Domain.Models
{
    public class Produto : Entity
    {
        public Produto() { }
       
        public Produto(string nome, string descricao, bool ativo, decimal valor, string imagem, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public string Nome { get;private set; }
        public string Descricao { get;private set; }
        public bool Ativo { get;private set; }
        public decimal Valor { get;private set; }
        public DateTime DataCadastro { get;private set; }
        public DateTime? DataAtualizacao { get;private set; }
        public string Imagem { get;private set; }
        public int QuantidadeEstoque { get;private set; }

        public IEnumerable<PedidoItem> PedidoItens { get; set; }

        public bool EstaDiponivel(int quantidade) =>
             QuantidadeEstoque >= quantidade && Ativo;

        public void RetirarEstoque(int quantidade)
        {
            if (EstaDiponivel(quantidade))
                QuantidadeEstoque -= quantidade;
            else
                throw new DomainException($"O produto {Nome} está esgotado!");
        }
    }
}
