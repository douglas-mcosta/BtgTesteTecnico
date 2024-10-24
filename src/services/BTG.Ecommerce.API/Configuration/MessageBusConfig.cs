using BTG.Core.Utils;
using BTG.Ecommerce.API.Services;
using BTG.MessageBus;
namespace BTG.Ecommerce.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroClienteIntegrationHandler>();
             
        }
    }
}
