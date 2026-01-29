using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileDeleteParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "delete", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;

        string path = tokens.Current;
        return new FileDeleteCommand(new PathObject(path));
    }
}