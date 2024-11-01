﻿using BTG.Core.Mediator;
using BTG.Ecommerce.Application.Commands.Clientes;
using BTG.Ecommerce.Application.Commands.Pedidos;
using BTG.Ecommerce.Application.Events.Clientes;
using BTG.Ecommerce.Application.Events.Pedidos;
using BTG.Ecommerce.Application.Queries.Pedidos;
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

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<ProcessarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            //Event
            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessadoEvent>, PedidoEventHandler>();

            //Queries
            services.AddScoped<IProdutoQueries, ProdutoQueries>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            //Data
            services.AddDbContext<EcommerceContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
