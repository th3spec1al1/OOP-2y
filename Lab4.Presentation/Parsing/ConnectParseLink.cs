using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class ConnectParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "connect", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;

        string path = tokens.Current;

        var connectionPath = new PathObject(path);
        ComponentNameObject rootDirName = connectionPath.Value[^1];

        var flags = ParseFlags(tokens).ToList();
        string mode = GetFlagValue(flags, "fsmode", "local");

        IFileSystem fileSystem = mode switch
        {
            "local" => new LocalFileSystem(new DirectoryFileSystemComponent(rootDirName)),
            _ => throw new ArgumentException($"Unknown file system mode: {mode}"),
        };

        return new ConnectCommand(connectionPath, fileSystem);
    }
}