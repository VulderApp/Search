using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Vulder.Search.Core.ProjectAggregate.School;
using Vulder.Search.Infrastructure.Data.Repository;
using Vulder.Search.Infrastructure.Handler.School;
using Module = Autofac.Module;

namespace Vulder.Search.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        
        public DefaultInfrastructureModule()
        {
            _assemblies.Add(Assembly.GetAssembly(typeof(School)));
            _assemblies.Add(Assembly.GetAssembly(typeof(FindSchoolRequestHandler)));
            _assemblies.Add(Assembly.GetAssembly(typeof(SchoolCreateRequestHandler)));
            _assemblies.Add(Assembly.GetAssembly(typeof(DeleteSchoolRequestHandler)));
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolRepository>()
                .As<ISchoolRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            
            var mediatROpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionHandler<,>),
                typeof(INotificationHandler<>),
            };
            
            foreach (var mediatROpenType in mediatROpenTypes)
            {
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatROpenType)
                    .AsImplementedInterfaces();
            }
        }
    }
}