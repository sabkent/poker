using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Application
{
    public interface IDispatchCommands
    {
        void Dispatch<TCommand>(TCommand command);
    }
}
