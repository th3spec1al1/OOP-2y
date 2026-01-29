using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileShowParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "show", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;

        string path = tokens.Current;

        var flags = ParseFlags(tokens).ToList();
        string mode = GetFlagValue(flags, "outmode", "console");

        IOutput output = mode switch
        {
            "console" => new ConsoleOutput(),
            _ => throw new ArgumentException($"Unknown file system mode: {mode}"),
        };

        return new FileShowCommand(output, new PathObject(path));
    }
}