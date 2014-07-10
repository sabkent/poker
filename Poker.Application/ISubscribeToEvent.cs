using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Application
{
    public interface ISubscribeToEvent<in TEvent>
    {
        void Notify(TEvent @event);
    }
}
