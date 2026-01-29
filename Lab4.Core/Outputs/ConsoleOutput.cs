using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;

public class ConsoleOutput : IOutput
{
    public void Write(string? text)
    {
        Console.Write(text);
    }

    public void WriteLine(string? text)
    {
        Console.WriteLine(text);
    }
}