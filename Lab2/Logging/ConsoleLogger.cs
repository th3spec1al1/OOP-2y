namespace Itmo.ObjectOrientedProgramming.Lab2.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss}] {message}");
    }
}