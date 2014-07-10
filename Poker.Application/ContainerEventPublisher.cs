using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Poker.Application
{
    public sealed class ContainerEventPublisher : IPublishEvents
    {
        private readonly IComponentContext _componentContext;

        public ContainerEventPublisher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Publish<TEvent>(TEvent @event)
        {
            var eventRaiserType = typeof (IEventRaiser<>).MakeGenericType(@event.GetType());
            var result = _componentContext.Resolve(eventRaiserType);

            ((dynamic) result).Raise(@event);
        }
    }

    public interface IEventRaiser<T>
    {
        void Raise(object @event);
    }

    public class EventRaiser<T> : IEventRaiser<T>
    {
        private readonly List<ISubscribeToEvent<T>> _handlers;

        public EventRaiser(IEnumerable<ISubscribeToEvent<T>> handlers)
        {
            _handlers = handlers.ToList();
        }

        public void Raise(object @event)
        {
            _handlers.ForEach(handler => handler.Notify((T) @event));
        }
    }
}
