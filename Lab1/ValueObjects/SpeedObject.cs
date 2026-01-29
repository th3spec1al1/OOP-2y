namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record SpeedObject
{
    public double Value { get; }

    public SpeedObject(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Speed cannot be negative");
        }

        Value = value;
    }

    public bool IsMore(SpeedObject other)
    {
        return Value > other.Value;
    }

    public bool IsZero()
    {
        return Value == 0;
    }

    public SpeedObject Plus(DeltaSpeedObject deltaSpeed)
    {
        return new SpeedObject(Value + deltaSpeed.Value);
    }
}