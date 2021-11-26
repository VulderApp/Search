using Microsoft.Extensions.DependencyInjection;

namespace Vulder.School.Infrastructure;

public static class StartupExtensions
{
    public static void AddDefaultCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CORS", corsPolicyBuilder =>
            {
                corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod();
            });
        });
    }
}