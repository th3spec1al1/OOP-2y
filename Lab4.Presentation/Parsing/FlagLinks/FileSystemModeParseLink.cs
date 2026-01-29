using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks;

public class FileSystemModeParseLink : BaseFlagParseLink
{
    protected override ICommandFlag? TryParse(string flag, CommandTokenIterator tokens)
    {
        if (flag == "-m")
        {
            if (tokens.MoveNext())
            {
                return new CommandFlag("fsmode", tokens.Current);
            }
        }

        return null;
    }
}