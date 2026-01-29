namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record DeltaSpeedObject
{
    public double Value { get; }

    public DeltaSpeedObject(double value)
    {
        Value = value;
    }

    public static DeltaSpeedObject CalculateDeltaSpeed(AccelerationObject acceleration, TimePrecisionObject timeStep)
    {
        double deltaSpeedValue = acceleration.Value * timeStep.Value;
        return new DeltaSpeedObject(deltaSpeedValue);
    }
}