using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandExecuteResult Execute(ISession session)
    {
        return session.Disconnect();
    }
}