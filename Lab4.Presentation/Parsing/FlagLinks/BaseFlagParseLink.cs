using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks;

public abstract class BaseFlagParseLink
{
    private BaseFlagParseLink? _next;

    public BaseFlagParseLink SetNext(BaseFlagParseLink next)
    {
        _next = next;
        return next;
    }

    public ICommandFlag? Parse(string flag, CommandTokenIterator tokens)
    {
        ICommandFlag? parsedFlag = TryParse(flag, tokens);

        if (parsedFlag == null && _next != null)
        {
            return _next.Parse(flag, tokens);
        }

        return parsedFlag;
    }

    protected abstract ICommandFlag? TryParse(string flag, CommandTokenIterator tokens);
}