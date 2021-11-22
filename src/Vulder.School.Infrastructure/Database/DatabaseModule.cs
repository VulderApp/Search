using Autofac;
using Vulder.School.Infrastructure.Database.Interface;
using Vulder.School.Infrastructure.Database.Repository;
using Module = Autofac.Module;

namespace Vulder.School.Infrastructure.Database;

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