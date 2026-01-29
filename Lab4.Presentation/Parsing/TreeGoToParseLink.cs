using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class TreeGoToParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "tree", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "goto", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;

        string path = tokens.Current;
        return new TreeGotoCommand(new PathObject(path));
    }
}