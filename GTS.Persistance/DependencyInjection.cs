using GTS.TaskManagement.Persistance.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GTS.TaskManagement.Persistance.Data.Interceptor;
using GTS.TaskManagement.Domain.Contract.Persistance;
using GTS.Persistance.Data.GenericRepository;
namespace GTS.TaskManagement.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>());
            });

            services.AddScoped(typeof(IGenricRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
