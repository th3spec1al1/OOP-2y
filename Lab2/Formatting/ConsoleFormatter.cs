namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

public class ConsoleFormatter : IMessageFormatter
{
    public void WriteHeader(string header)
    {
        Console.WriteLine(header);
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(body);
    }
}