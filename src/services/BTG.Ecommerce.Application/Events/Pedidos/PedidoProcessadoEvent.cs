using BTG.Core.Messages;
using BTG.Core.Messages.Integration;
using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Application.Events.Pedidos
{
    public class PedidoProcessadoEvent : Event
    {
        public PedidoProcessadoEvent(Guid clienteId,string clienteNome, Guid pedidoId, int codigoPedido, List<PedidoItem> itens)
        {
            ClienteId = clienteId;
            ClienteNome = clienteNome;
            PedidoId = pedidoId;
            Itens = itens.Select(ParaItemIntregracao).ToList();
            CodigoPedido = codigoPedido;
        }

        public Guid ClienteId { get; private set; }
        public string ClienteNome { get; private set; }
        public Guid PedidoId { get; private set; }
        public int CodigoPedido { get; private set; }
        public List<PedidoItensProcessado> Itens { get; private set; }

        public PedidoItensProcessado ParaItemIntregracao(PedidoItem item)
        {
            if (item is null) return new PedidoItensProcessado();

            return new PedidoItensProcessado
            {
                Id = item.Id,
                Preco = item.ValorUnitario,
                Produto = item.ProdutoNome,
                Quantidade = item.Quantidade
            };
        }

    }
}
