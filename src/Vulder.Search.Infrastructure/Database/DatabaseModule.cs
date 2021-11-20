using Autofac;
using Vulder.Search.Infrastructure.Database.Interface;
using Vulder.Search.Infrastructure.Database.Repository;
using Module = Autofac.Module;

namespace Vulder.Search.Infrastructure.Database;

public class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MongoDbContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<SchoolRepository>()
            .As<ISchoolRepository>()
            .InstancePerLifetimeScope();
    }
}