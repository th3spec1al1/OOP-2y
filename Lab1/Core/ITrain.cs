using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Core;

public interface ITrain
{
    WeightObject Weight { get; }

    MaxForceObject MaxForce { get; }

    TimePrecisionObject TimePrecision { get; }

    SpeedObject Speed { get; }

    ForceObject CurrentForce { get; }

    AccelerationObject Acceleration { get; }

    ForceApplicationResult ApplyForce(ForceObject force);

    MoveResult CalculateTimeForDistance(LengthObject distance);
}