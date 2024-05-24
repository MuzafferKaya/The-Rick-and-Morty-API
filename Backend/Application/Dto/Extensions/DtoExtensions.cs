using Dto.Request.Character;
using Dto.Request.Episode;
using Dto.Request.Location;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dto.Extensions
{
    public static class DtoExtensions
    {
        public static IServiceCollection LoadDtoExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<EpisodeCreateRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<EpisodeUpdateRequestDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<CharacterCreateRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CharacterUpdateRequestDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<LocationCreateRequestDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<LocationUpdateRequestDtoValidator>();
            return services;
        }
    }
}
