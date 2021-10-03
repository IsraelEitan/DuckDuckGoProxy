using DuckDuckGo.Application.Interfaces;
using DuckDuckGo.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDuckGo.Infrastructure
{
    public static class Injectcion
    {
        public static IServiceCollection RegisterInfrastructerServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IDuckDuckGoAPIService, DuckDuckGoAPIService>();
            return services;
        }
    }
}