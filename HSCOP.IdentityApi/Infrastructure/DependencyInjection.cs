using HSCOP.Identity.Service;
using HSCOP.Identity.Service.Options;
using Microsoft.AspNetCore.Authentication;

namespace HSCOP.Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterInjectedServices(this IServiceCollection services, IConfiguration configuration)
        {
            SetConfigurationOptions(services, configuration);
            ConfigureScopedServices(services);
        }

        private static void SetConfigurationOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));
        }

        private static void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticateService, AuthenticateService>();
        }
    }
}
