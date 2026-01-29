namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;

public class CommandFlag : ICommandFlag
{
    public CommandFlag(string name, string? value = null)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public string? Value { get; }
}