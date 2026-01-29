using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public abstract class BaseCommandParseLink
{
    private BaseCommandParseLink? _next;

    public BaseCommandParseLink SetNext(BaseCommandParseLink next)
    {
        _next = next;
        return next;
    }

    public ICommand? Parse(CommandTokenIterator tokens)
    {
        ICommand? command = TryParse(tokens);

        if (command == null && _next != null)
            return _next.Parse(tokens);

        return command;
    }

    protected abstract ICommand? TryParse(CommandTokenIterator tokens);
}