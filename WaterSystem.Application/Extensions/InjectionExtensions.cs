using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WaterSystem.Application.Interfaces;
using WaterSystem.Application.Services;

namespace WaterSystem.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration) {

            services.AddSingleton(configuration);
            //AddFluentValidation

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(P => !P.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ISettlementApplication, SettlementApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            return services;
        }
    }
}
