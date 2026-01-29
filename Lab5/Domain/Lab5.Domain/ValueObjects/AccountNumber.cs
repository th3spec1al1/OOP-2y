namespace Lab5.Domain.ValueObjects;

public readonly record struct AccountNumber
{
    public int Number { get; }

    public AccountNumber(int number)
    {
        Number = number;
    }
}