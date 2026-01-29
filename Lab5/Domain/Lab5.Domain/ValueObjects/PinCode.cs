namespace Lab5.Domain.ValueObjects;

public readonly record struct PinCode
{
    public int Value { get; }

    public PinCode(int value)
    {
        Value = value;
    }
}