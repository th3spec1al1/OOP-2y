namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

public class UpperFormatting : IMessageFormatter
{
    private readonly IMessageFormatter _messageFormatter;

    public UpperFormatting(IMessageFormatter messageFormatter)
    {
        _messageFormatter = messageFormatter;
    }

    public void WriteHeader(string header)
    {
        _messageFormatter.WriteHeader($"{header.ToUpperInvariant()}\n");
    }

    public void WriteBody(string body)
    {
        _messageFormatter.WriteBody($"{body.ToUpperInvariant()}\n");
    }
}