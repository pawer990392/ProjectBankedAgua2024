using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace WaterSystem.Api.Extensions
{
    public static class SwaggerExtensions
    {
        //documentacion de swagger Checarlo mañana 
        public static IServiceCollection AddSwagger(this IServiceCollection services) {

            var openApi = new OpenApiInfo
            {
                Title = "SistemasAgua2024",
                Version = "Version1",
                Description = "Elaborando Sistema de agua 2024",
                TermsOfService = new Uri("https://opensource.org/licenses/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "Miguel Angel Garcia Martinez",
                    Email = "rander2020.120.drz32@gail.com",
                    Url = new Uri("https://opensource.org/licenses/")

                },
                License = new OpenApiLicense
                {
                    Name = "Projecto Sistema Of Agua 2024",
                    Url= new Uri("https://opensource.org/licenses/")
                }
            };
            services.AddSwaggerGen(x =>
            {
                openApi.Version= "version1";
                x.SwaggerDoc("version1", openApi);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "JWT Token Miguel",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                x.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySchema,new string [] {} }
                });

            });
            return services;
        }
    }
}
