using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly PathObject _path;
    private readonly ComponentNameObject _newName;

    public FileRenameCommand(PathObject path, ComponentNameObject newName)
    {
        _path = path;
        _newName = newName;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        if (session.FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        return session.FileSystem.RenameFile(session.ConnectionPath.Plus(_path), _newName);
    }
}