namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record ReceivedMessageResult
{
    private ReceivedMessageResult() { }

    public sealed record Success : ReceivedMessageResult;

    public sealed record LowImportance : ReceivedMessageResult;

    public sealed record WithoutKeywords : ReceivedMessageResult;

    public sealed record Failure : ReceivedMessageResult;
}