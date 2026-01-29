namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record ForceObject
{
    public double Value { get; }

    public ForceObject(double value)
    {
        Value = value;
    }

    public static ForceObject CalculateForce(SpeedObject speed, WeightObject weight)
    {
        double forceValue = speed.Value * weight.Value;
        return new ForceObject(forceValue);
    }
}