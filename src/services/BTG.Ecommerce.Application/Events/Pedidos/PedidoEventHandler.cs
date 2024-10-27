using BTG.Core.Messages.Integration;
using BTG.MessageBus;
using MediatR;

namespace BTG.Ecommerce.Application.Events.Pedidos
{
    public class PedidoEventHandler : INotificationHandler<PedidoProcessadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PedidoProcessadoEvent notification, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new PedidoProcessadoIntegrationEvent(notification.ClienteId, notification.PedidoId, notification.CodigoPedido, notification.Itens));
        }
    }
}