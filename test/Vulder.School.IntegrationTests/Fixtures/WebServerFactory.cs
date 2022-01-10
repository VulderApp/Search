using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Vulder.School.IntegrationTests.Fixtures;

public class WebServerFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("MONGODB_CONNECTION_STRING", "mongodb://localhost:27017/");

        builder.UseEnvironment("Production");
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .AddEnvironmentVariables();
        });
    }

    protected override void ConfigureClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {FakeJwtTokenGenerator.GetToken()}");
        
        base.ConfigureClient(client);
    }
}