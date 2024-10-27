using BTG.Relatorio.API.Data.Repository;

namespace BTG.Relatorio.API.Configuration
{
    public static class DependencieInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            //Message
            services.AddMessageBusConfiguration(configuration);


            services.AddScoped<IPedidoRepository, PedidoRepository>();
            return services;
        }
    }
}
