using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WaterSystem.Infrastructure.Persistences.Contexts;
using WaterSystem.Infrastructure.Persistences.Interfaces;
using WaterSystem.Infrastructure.Persistences.Repositories;

namespace WaterSystem.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services,IConfiguration configuration) {
            
            var assambly = typeof(SistemasCobroAgua2024Context).Assembly.FullName;

            services.AddDbContext<SistemasCobroAgua2024Context>(

                options => options.UseSqlServer(configuration.GetConnectionString("SistemaDbWater2024"),
                           b => b.MigrationsAssembly(assambly)), ServiceLifetime.Transient);
            //registar el patron unit of work como ciclo de vida servicio trasnsiert
            /*
             AddTransient crea una nueva instancia cada vez que se solicita, mientras que 
             AddScoped crea una instancia por solicitud HTTP y la reutiliza dentro del mismo 
             alcance de la solicitud.
             */
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }   
    }
}
