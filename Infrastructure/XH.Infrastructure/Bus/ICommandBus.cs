using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Command;

namespace XH.Infrastructure.Bus
{
    public interface ICommandBus
    {
        /// <summary>
        /// Send the command
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        void Send<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Send the command
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand
                                                          where TResult : ICommandResult;
    }
}
