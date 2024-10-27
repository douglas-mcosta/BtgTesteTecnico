using BTG.Core.Messages.Integration;
using BTG.MessageBus;
using BTG.Relatorio.API.Data.Repository;
using BTG.Relatorio.API.Model;

namespace BTG.Relatorio.API.Services
{
    public class PedidoProcessadoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PedidoProcessadoIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.Subscribe<PedidoProcessadoIntegrationEvent>("PedidoProcessado", async request => await AdicionarPedido(request));

        }

        private async Task AdicionarPedido(PedidoProcessadoIntegrationEvent message)
        {

            var pedido = new Pedido
            {
                Id = message.PedidoId,
                CodigoCliente = message.ClienteId,
                CodigoPedido = message.CodigoPedido,
            };

            foreach (var item in message.Itens)
            {
                pedido.Itens.Add(new PedidoItem
                {
                    Id = item.Id,
                    PedidoId = message.PedidoId,
                    Preco = item.Preco,
                    Produto = item.Produto,
                    Quantidade = item.Quantidade,
                });
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IPedidoRepository>();
                repository.Adicionar(pedido);
                await repository.UnitOfWork.Commit();
            }
        }
    }
}