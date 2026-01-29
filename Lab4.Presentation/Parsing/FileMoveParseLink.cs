using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileMoveParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "move", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;

        string source = tokens.Current;
        if (!tokens.MoveNext()) return null;

        string destination = tokens.Current;
        return new FileMoveCommand(new PathObject(source), new PathObject(destination));
    }
}