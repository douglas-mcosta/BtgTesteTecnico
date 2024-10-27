namespace BTG.Core.Messages.Integration
{
    public class PedidoProcessadoIntegrationEvent : IntegrationEvent
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public int CodigoPedido { get; private set; }
        public string ClienteNome { get; private set; }
        public IEnumerable<PedidoItensProcessado> Itens { get; private set; }

        public PedidoProcessadoIntegrationEvent(Guid clienteId, string clienteNome, Guid pedidoId, int codigoPedido, IEnumerable<PedidoItensProcessado> itens)
        {
            ClienteId = clienteId;
            ClienteNome = clienteNome;
            PedidoId = pedidoId;
            Itens = itens;
            CodigoPedido = codigoPedido;
        }
    }
}