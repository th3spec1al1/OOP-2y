namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record AccelerationObject
{
    public double Value { get; }

    public AccelerationObject(double value)
    {
        Value = value;
    }

    public bool IsZero()
    {
        return Value == 0;
    }

    public static AccelerationObject CalculateAcceleration(ForceObject force, WeightObject weight)
    {
        double accelerationValue = force.Value / weight.Value;
        return new AccelerationObject(accelerationValue);
    }
}