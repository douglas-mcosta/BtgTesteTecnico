using BTG.Core.DomainObjects;

namespace BTG.Ecommerce.Domain.Models
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string ProdutoImagem { get; private set; }

        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }

        public PedidoItem(Guid pedidoId, Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario, string produtoImagem) : this(produtoId, produtoNome, quantidade, valorUnitario, produtoImagem)
        {
            PedidoId = pedidoId;
        }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario, string produtoImagem) : this()
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ProdutoImagem = produtoImagem;
        }

        private PedidoItem() { }

        public decimal CalcularValor() => Quantidade * ValorUnitario;
        internal decimal SomarQuantidade(int quantidade) => Quantidade += quantidade;
    }
}