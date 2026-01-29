using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly PathObject _path;

    public FileDeleteCommand(PathObject path)
    {
        _path = path;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        if (session.FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        return session.FileSystem.DeleteFile(session.ConnectionPath.Plus(_path));
    }
}