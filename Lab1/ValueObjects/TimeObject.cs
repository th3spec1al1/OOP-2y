namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record TimeObject
{
    public double Value { get; }

    public TimeObject(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Time cannot be negative");
        }

        Value = value;
    }

    public TimeObject Plus(TimeObject other)
    {
        return new TimeObject(Value + other.Value);
    }

    public TimeObject Plus(TimePrecisionObject other)
    {
        return new TimeObject(Value + other.Value);
    }
}