using Lab5.Domain.Accounts;

namespace Lab5.Domain.ResultTypes;

public abstract record TransactionResult
{
    private TransactionResult() { }

    public sealed record Success(TransactionItem TransactionItem) : TransactionResult;

    public sealed record Failure(string Message) : TransactionResult;
}