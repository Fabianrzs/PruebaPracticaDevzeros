using BLL;
using BLL.Interface;
using BLL.Service;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Presentacion.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar los servicios del repositorio génerico
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
