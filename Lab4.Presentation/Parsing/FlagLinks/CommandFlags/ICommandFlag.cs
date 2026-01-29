namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;

public interface ICommandFlag
{
    string Name { get; }

    string? Value { get; }
}