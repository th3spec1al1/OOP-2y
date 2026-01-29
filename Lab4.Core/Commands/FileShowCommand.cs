using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly IOutput _output;
    private readonly PathObject _path;

    public FileShowCommand(IOutput output, PathObject path)
    {
        _output = output;
        _path = path;
    }

    public CommandExecuteResult Execute(ISession session)
    {
        if (session.FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        FileContentObject? fileContent = session.FileSystem.ReadFile(session.ConnectionPath.Plus(_path));
        if (fileContent is null)
            return new CommandExecuteResult.Failure("No file to this path");

        _output.WriteLine(fileContent.Value);
        return new CommandExecuteResult.Success();
    }
}