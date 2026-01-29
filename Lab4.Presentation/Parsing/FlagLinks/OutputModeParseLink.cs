using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks;

public class OutputModeParseLink : BaseFlagParseLink
{
    protected override ICommandFlag? TryParse(string flag, CommandTokenIterator tokens)
    {
        if (flag == "-m")
        {
            if (tokens.MoveNext())
            {
                return new CommandFlag("outmode", tokens.Current);
            }
        }

        return null;
    }
}