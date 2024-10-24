using System;
using System.Collections.Generic;

namespace BTG.Core.Messages.Integration
{
    public class PedidoAutorizadoIntegrationEvent : IntegrationEvent
    {
        public PedidoAutorizadoIntegrationEvent(Guid clienteId, Guid pedidoId, IDictionary<Guid, int> itens)
        {
            ClienteId = clienteId;
            PedidoId = pedidoId;
            Itens = itens;
        }

        public Guid ClienteId { get; set; }
        public Guid PedidoId { get; set; }
        public IDictionary<Guid, int> Itens { get; set; }
    }
}
