using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Command;

namespace XH.Infrastructure.Bus
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryCommandBus : ICommandBus
    {
        private readonly IComponentContext _componentContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="componentContext"></param>
        public InMemoryCommandBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> commandHandler = _componentContext.Resolve<ICommandHandler<TCommand>>();
            Contract.Assert(commandHandler != null);

            commandHandler.Handle(command);
        }

        public TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand
                                                                 where TResult : ICommandResult
        {
            ICommandHandler<TCommand, TResult> commandHandler = _componentContext.Resolve<ICommandHandler<TCommand, TResult>>();
            Contract.Assert(commandHandler != null);

            return commandHandler.Handle(command);
        }
    }
}
