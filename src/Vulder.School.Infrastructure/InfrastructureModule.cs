using Autofac;
using AutoMapper;
using Vulder.School.Infrastructure.AutoMapper;
using Vulder.School.Infrastructure.Database;
using Module = Autofac.Module;

namespace Vulder.School.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new DatabaseModule());
        
        builder.Register(_ => new MapperConfiguration(c => { c.AddProfile<AutoMapperProfile>(); }));
        builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
    }
}