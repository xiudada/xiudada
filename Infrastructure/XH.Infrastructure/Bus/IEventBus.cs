using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Bus
{
    public interface IEventBus : IBus
    {
        /// <summary>
        /// Publish the event to memory bus
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        void Send<TEvent>(TEvent @event) where TEvent : IEvent;

        /// <summary>
        /// Publish the event to service bus
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        void SendAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
