using GTS.Application.Mapping;
using GTS.Application.Services;
using GTS.TaskManagement.Domain.Contract.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GTS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IToDoServices, ToDoServices>();

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
