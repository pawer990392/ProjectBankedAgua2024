﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace WaterSystem.Test
{
    public class CustomWebAppicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(ConfigurationBuilder =>
            {
                var integrationConfiguration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                AddEnvironmentVariables()
                .Build();
                ConfigurationBuilder.AddConfiguration(integrationConfiguration);
            });
        }

    }
}
