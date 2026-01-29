namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record MaxForceObject
{
    public double Value { get; }

    public MaxForceObject(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("MaxForce cannot be negative");
        }

        Value = value;
    }

    public bool CanApply(ForceObject force)
    {
        return Value >= force.Value;
    }
}