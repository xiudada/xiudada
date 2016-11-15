using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Event;

namespace XH.Infrastructure.Bus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IComponentContext _componentContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="componentContext"></param>
        public InMemoryEventBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        /// <summary>
        /// Publish the event
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        public void Send<TEvent>(TEvent @event) where TEvent : IEvent
        {
            IEnumerable<IEventHandler<TEvent>> eventHandlers = null;
            if (_componentContext.TryResolve<IEnumerable<IEventHandler<TEvent>>>(out eventHandlers))
            {
                foreach (IEventHandler<TEvent> eventHandler in eventHandlers)
                {
                    eventHandler.Handle(@event);
                }
            }
        }

        /// <summary>
        /// Publish the event
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        public void SendAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
