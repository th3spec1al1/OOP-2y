using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly PathObject _path;

    public TreeGotoCommand(PathObject path)
    {
        _path = path;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        return session.TreeGoTo(_path);
    }
}