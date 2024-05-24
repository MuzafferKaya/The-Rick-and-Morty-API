using DomainModel.Context;
using DomainModel.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainModel.Extensions
{
    public static class DomainModelExtensions
    {
        public static IServiceCollection LoadDomainModelExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository.Repository<>));
            return services;
        }
    }
}
