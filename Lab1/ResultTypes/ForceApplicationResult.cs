namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record ForceApplicationResult
{
    private ForceApplicationResult() { }

    public sealed record Success : ForceApplicationResult;

    public sealed record Failure(string Message) : ForceApplicationResult;
}