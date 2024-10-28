using BTG.Core.DomainObjects;

namespace BTG.Relatorio.API.Model
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }
        public Guid CodigoCliente { get; set; }
        public int CodigoPedido { get; set; }
        public string NomeCliente { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
