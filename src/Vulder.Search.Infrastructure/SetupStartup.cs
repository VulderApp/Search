using Microsoft.Extensions.DependencyInjection;
using Vulder.Search.Infrastructure.Data;

namespace Vulder.Search.Infrastructure
{
    public static class SetupStartup
    {
        public static void AddMongoDb(this IServiceCollection services)
            => services.AddSingleton<MongoDbContext>();
    }
}