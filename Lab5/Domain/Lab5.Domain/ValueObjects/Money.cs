namespace Lab5.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }

    public static Money Zero => new Money(0);

    public Money(decimal amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Money amount cannot be negative");
        Amount = amount;
    }

    public bool IsMoreThan(Money other)
    {
        return Amount > other.Amount;
    }

    public Money Plus(Money other)
    {
        return new Money(Amount + other.Amount);
    }

    public Money Minus(Money other)
    {
        return new Money(Amount - other.Amount);
    }
}