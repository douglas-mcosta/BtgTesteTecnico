using BTG.Core.Mediator;
using BTG.Ecommerce.Application.Commands.Clientes;
using BTG.Ecommerce.Application.Events.Clientes;
using BTG.Ecommerce.Application.Queries.Produtos;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Infra.Context;
using BTG.Ecommerce.Infra.Repository;
using BTG.WebAPI.Core.User;
using FluentValidation.Results;
using MediatR;

namespace BTG.Ecommerce.API.Configuration
{
    public static class DependencieInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            //Message
            services.AddMessageBusConfiguration(configuration);
            //API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            //Event
            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            //Queries
            services.AddScoped<IProdutoQueries, ProdutoQueries>();

            //Data
            services.AddDbContext<EcommerceContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
