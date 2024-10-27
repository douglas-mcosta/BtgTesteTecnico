using BTG.Core.DomainObjects;

namespace BTG.Relatorio.API.Model
{
    public class PedidoItem : Entity
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        
    }
}
