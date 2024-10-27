using BTG.Core.Utils;
using BTG.MessageBus;
using BTG.Relatorio.API.Services;
namespace BTG.Relatorio.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<PedidoProcessadoIntegrationHandler>();

        }
    }
}
