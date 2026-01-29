using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopyCommand : ICommand
{
    private readonly PathObject _sourcePath;
    private readonly PathObject _destinationPath;

    public FileCopyCommand(PathObject sourcePath, PathObject destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        if (session.FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        PathObject fullSourcePath = session.ConnectionPath.Plus(_sourcePath);
        PathObject fullDestinationPath = session.ConnectionPath.Plus(_destinationPath);
        return session.FileSystem.MoveFile(fullSourcePath, fullDestinationPath);
    }
}