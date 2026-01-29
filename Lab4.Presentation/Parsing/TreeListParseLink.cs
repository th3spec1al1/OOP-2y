using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class TreeListParseLink : BaseCommandWithFlagsParseLink
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "tree", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "list", StringComparison.OrdinalIgnoreCase)) return null;

        var flags = ParseFlags(tokens).ToList();
        int depth = GetFlagValue(flags, "depth", -1);
        if (depth == -1) return null;

        return new TreeListCommand(new ConsoleOutput(), depth);
    }
}