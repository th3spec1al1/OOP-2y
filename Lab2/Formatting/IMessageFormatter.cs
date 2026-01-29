namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

public interface IMessageFormatter
{
    void WriteHeader(string header);

    void WriteBody(string body);
}