using BTG.Clientes.Domain.Interfaces;
using BTG.Clientes.Infra.Context;
using BTG.Clientes.Infra.Repository;
using BTG.Core.Mediator;
using BTG.WebAPI.Core.User;

namespace BTG.Clientes.API.Configuration
{
    public static class DependencieInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            //API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Data
            services.AddDbContext<ClienteContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
