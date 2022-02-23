using Autofac;
using Vulder.School.Infrastructure.Redis.Interfaces;
using Vulder.School.Infrastructure.Redis.Repositories;

namespace Vulder.School.Infrastructure.Redis;

public class RedisModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RedisContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<SchoolCacheRepository>()
            .As<ISchoolCacheRepository>()
            .InstancePerLifetimeScope();
    }
}