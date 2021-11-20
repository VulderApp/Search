using Autofac;
using AutoMapper;
using Vulder.Search.Infrastructure.AutoMapper;
using Vulder.Search.Infrastructure.Database;
using Module = Autofac.Module;

namespace Vulder.Search.Infrastructure;

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