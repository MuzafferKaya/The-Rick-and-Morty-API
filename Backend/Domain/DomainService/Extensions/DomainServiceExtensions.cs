using DomainService.Abstract;
using DomainService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService.Extensions
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection LoadDomainServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}
