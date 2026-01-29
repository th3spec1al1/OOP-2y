using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Core;

public class Train : ITrain
{
    public WeightObject Weight { get; }

    public MaxForceObject MaxForce { get; }

    public TimePrecisionObject TimePrecision { get; }

    public SpeedObject Speed { get; private set; }

    public ForceObject CurrentForce { get; private set; }

    public AccelerationObject Acceleration { get; private set; }

    public Train(
        WeightObject weight,
        MaxForceObject maxForce,
        TimePrecisionObject timePrecision)
    {
        Weight = weight;
        MaxForce = maxForce;
        TimePrecision = timePrecision;
        Speed = new SpeedObject(0);
        CurrentForce = new ForceObject(0);
        Acceleration = new AccelerationObject(0);
    }

    public ForceApplicationResult ApplyForce(ForceObject force)
    {
        if (!MaxForce.CanApply(force))
        {
            return new ForceApplicationResult.Failure("Force is more than train's max force");
        }

        var newAcceleration = AccelerationObject.CalculateAcceleration(force, Weight);
        CurrentForce = force;
        Acceleration = newAcceleration;

        return new ForceApplicationResult.Success();
    }

    public MoveResult CalculateTimeForDistance(LengthObject distance)
    {
        if (Speed.IsZero() && Acceleration.IsZero())
        {
            return new MoveResult.Failure("Train cannot move: no speed and no acceleration");
        }

        var passedDistance = new LengthObject(0);
        var totalTime = new TimeObject(0);

        SpeedObject newSpeed = Speed;
        var deltaSpeed = DeltaSpeedObject.CalculateDeltaSpeed(Acceleration, TimePrecision);

        while (!passedDistance.IsMoreOrEqual(distance))
        {
            newSpeed = newSpeed.Plus(deltaSpeed);
            var deltaDistance = LengthObject.CalculateDeltaDistance(newSpeed, TimePrecision);

            passedDistance = passedDistance.Plus(deltaDistance);
            totalTime = totalTime.Plus(TimePrecision);
        }

        if (!passedDistance.IsMoreOrEqual(distance))
        {
            return new MoveResult.Failure("Train cannot cover this distance");
        }

        Speed = newSpeed;

        return new MoveResult.Success(totalTime);
    }
}