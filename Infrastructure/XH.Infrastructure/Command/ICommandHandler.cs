using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Bus;

namespace XH.Infrastructure.Command
{
    public interface ICommandHandler<in TCommand> : IHandler<TCommand> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, out TCommandResult> : IHandler<TCommand, TCommandResult> where TCommand : ICommand where TCommandResult : ICommandResult
    {
    }
}
