using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BTG.WebAPI.Core.Identidate
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            //JWT
            var appSettingsSection = configuration.GetSection("TokenSettings");
            services.Configure<TokenSettings>(appSettingsSection);

            //Enconde
            var appSettings = appSettingsSection.Get<TokenSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Config Auth
            services.AddAuthentication(x => {
                //Padrão de autenticação e validação trabalharam com JWT
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });

            return services;
        }

        public static IApplicationBuilder UseJwtConfiguration(this IApplicationBuilder app)
        {

            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
