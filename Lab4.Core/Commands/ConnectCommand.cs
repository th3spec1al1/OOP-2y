using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly PathObject _path;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(PathObject path, IFileSystem fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        return session.Connect(_fileSystem, session.ConnectionPath.Plus(_path));
    }
}