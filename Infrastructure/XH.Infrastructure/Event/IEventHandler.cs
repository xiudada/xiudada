using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Bus;

namespace XH.Infrastructure.Event
{
    public interface IEventHandler<in TEvent> : IHandler<TEvent>
        where TEvent : IEvent
    {
    }
}