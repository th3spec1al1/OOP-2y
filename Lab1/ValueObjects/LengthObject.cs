namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record LengthObject
{
    public double Value { get; }

    public LengthObject(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Length cannot be negative");
        }

        Value = value;
    }

    public LengthObject Plus(LengthObject other)
    {
        return new LengthObject(Value + other.Value);
    }

    public bool IsMoreOrEqual(LengthObject other)
    {
        return Value >= other.Value;
    }

    public static LengthObject CalculateDeltaDistance(SpeedObject speed, TimePrecisionObject timeStep)
    {
        double deltaDistanceValue = speed.Value * timeStep.Value;
        return new LengthObject(deltaDistanceValue);
    }
}