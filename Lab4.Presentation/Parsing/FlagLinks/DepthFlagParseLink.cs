using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks;

public class DepthFlagParseLink : BaseFlagParseLink
{
    protected override ICommandFlag? TryParse(string flag, CommandTokenIterator tokens)
    {
        if (flag == "-d")
        {
            if (tokens.MoveNext())
            {
                return new CommandFlag("depth", tokens.Current);
            }
        }

        return null;
    }
}