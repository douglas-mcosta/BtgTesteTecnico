using Microsoft.Extensions.DependencyInjection;
using System;

namespace BTG.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentException("Informe a connection string");

            services.AddSingleton<IMessageBus>(new MessageBus(connection));
            return services;
        }
    }
}
