namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

public class MarkdownFormatter : IMessageFormatter
{
    private readonly IMessageFormatter _messageFormatter;

    public MarkdownFormatter(IMessageFormatter messageFormatter)
    {
        _messageFormatter = messageFormatter;
    }

    public void WriteHeader(string header)
    {
        _messageFormatter.WriteHeader($"#{header}\n");
    }

    public void WriteBody(string body)
    {
        _messageFormatter.WriteBody($"{body}\n");
    }
}