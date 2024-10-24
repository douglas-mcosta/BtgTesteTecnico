using BTG.Core.Mediator;
using BTG.Identidade.API.Services.NSE.Identidade.API.Services;
using BTG.WebAPI.Core.User;
using System.Reflection;

namespace BTG.Identidade.API.Configuration
{
    public static class DependencieInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            //Message
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddMessageBusConfiguration(configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            return services;
        }
    }
}
