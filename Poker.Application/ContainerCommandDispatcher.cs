using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Poker.Application
{
    public class ContainerCommandDispatcher : IDispatchCommands
    {
        private readonly IComponentContext _componentContext;

        public ContainerCommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Dispatch<TCommand>(TCommand command)
        {
            var handlerType = typeof (IHandleCommand<TCommand>);

            var handler = _componentContext.Resolve(handlerType) as IHandleCommand<TCommand>;
            if(handler == null)
                throw new Exception();
            handler.Handle(command);
        }
    }
}
