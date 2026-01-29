using Itmo.ObjectOrientedProgramming.Lab2.Core;
using Itmo.ObjectOrientedProgramming.Lab2.Formatting;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archive;

public class FormattingArchiver : IArchiver
{
    private readonly IMessageFormatter _formatter;

    public FormattingArchiver(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Archive(Message message)
    {
        _formatter.WriteHeader(message.Title.Value);
        _formatter.WriteBody(message.Body.Value);
    }
}