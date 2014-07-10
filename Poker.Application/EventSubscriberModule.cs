using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Poker.Application
{
    public class EventSubscriberModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContainerEventPublisher>().As<IPublishEvents>();

            builder.RegisterGeneric(typeof(EventRaiser<>)).As(typeof(IEventRaiser<>));

            var assembly = typeof(EventSubscriberModule).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssiableFromGenericType(typeof(ISubscribeToEvent<>)))
                .AsClosedTypesOf(typeof(ISubscribeToEvent<>));

            base.Load(builder);
        }
    }
}
