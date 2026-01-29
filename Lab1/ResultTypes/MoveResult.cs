using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record MoveResult
{
    private MoveResult() { }

    public sealed record Success(TimeObject Time) : MoveResult;

    public sealed record Failure(string Message) : MoveResult;
}