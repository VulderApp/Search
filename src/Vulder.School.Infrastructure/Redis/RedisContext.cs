using StackExchange.Redis;
using Vulder.School.Core;

namespace Vulder.School.Infrastructure.Redis;

public class RedisContext
{
    public RedisContext()
    {
        var redis = ConnectionMultiplexer.Connect(Constants.RedisConnectionString);
        Schools = redis.GetDatabase(0);
    }
    
    public IDatabase Schools { get; set; }
}