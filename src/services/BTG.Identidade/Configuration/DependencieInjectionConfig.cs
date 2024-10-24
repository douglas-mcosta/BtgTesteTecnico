using BTG.Identidade.API.Services.NSE.Identidade.API.Services;
using BTG.WebAPI.Core.User;

namespace BTG.Identidade.API.Configuration
{
    public static class DependencieInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            return services;
        }
    }
}
