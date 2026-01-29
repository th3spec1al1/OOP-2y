namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record WeightObject
{
    public double Value { get; }

    public WeightObject(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Weight cannot be negative or equal to zero");
        }

        Value = value;
    }
}