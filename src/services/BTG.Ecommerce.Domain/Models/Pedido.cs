using BTG.Core.DomainObjects;
using BTG.Core.Enums;

namespace BTG.Ecommerce.Domain.Models
{
    public class Pedido : Entity
    {
        public Pedido(Guid clienteId, List<PedidoItem> pedidoItems)
        {
            ClienteId = clienteId;
            _pedidoItems = pedidoItems;

        }

        private Pedido() { }

        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        public Cliente Cliente { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public Endereco Endereco { get; private set; }

        public void RealizarPedido() =>
            PedidoStatus = PedidoStatus.AguardandoPagamento;

        public void AtribuirEndereco(Endereco endereco) =>
            Endereco = endereco;

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
        }

        public void Pago() =>
            PedidoStatus = PedidoStatus.Pago;

        public void PagamentoRecusado() =>
            PedidoStatus = PedidoStatus.PagamentoRecusado;
    }
}