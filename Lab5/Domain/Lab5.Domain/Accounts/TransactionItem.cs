using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public record TransactionItem
{
    public Guid Id { get; }

    public Guid AccountId { get; }

    public TransactionType TransactionType { get; }

    public DateTime Time { get; }

    public Money Amount { get; }

    public Money ResultBalance { get; }

    public TransactionItem(
        Guid accountId,
        TransactionType transactionType,
        Money amount,
        Money resultBalance)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
        TransactionType = transactionType;
        Time = DateTime.Now;
        Amount = amount;
        ResultBalance = resultBalance;
    }
}