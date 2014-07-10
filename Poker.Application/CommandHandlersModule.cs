using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Poker.Application
{
    public class CommandHandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof (CommandHandlersModule).Assembly;

            builder.RegisterType<ContainerCommandDispatcher>().As<IDispatchCommands>();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssiableFromGenericType(typeof(IHandleCommand<>)))
                .AsClosedTypesOf(typeof(IHandleCommand<>));

            base.Load(builder);
        }
    }
}
