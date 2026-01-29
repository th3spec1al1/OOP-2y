using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly IOutput _output;
    private readonly int _maxDepth;

    public TreeListCommand(IOutput output, int maxDepth)
    {
        _output = output;
        _maxDepth = maxDepth;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        if (session.FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        PathObject fullPath = session.ConnectionPath.Plus(session.LocalPath);
        DirectoryFileSystemComponent? directory = session.FileSystem.GetDirectoryByPath(fullPath);
        if (directory is null)
            return new CommandExecuteResult.Failure("Error with current direction");

        var visitor = new OutputVisitor(_output, _maxDepth);
        visitor.Visit(directory);

        return new CommandExecuteResult.Success();
    }
}
