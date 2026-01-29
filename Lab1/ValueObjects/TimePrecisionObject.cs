namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record TimePrecisionObject
{
    public double Value { get; }

    public TimePrecisionObject(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("TimePrecision cannot be negative or equal to zero");
        }

        Value = value;
    }
}