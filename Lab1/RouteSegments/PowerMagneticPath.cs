using Itmo.ObjectOrientedProgramming.Lab1.Core;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public record PowerMagneticPath : IRouteSegment
{
    private readonly LengthObject _length;

    private readonly ForceObject _force;

    public PowerMagneticPath(LengthObject length, ForceObject force)
    {
        _length = length;
        _force = force;
    }

    public MoveResult PassRouteSegment(ITrain train)
    {
        ForceObject originalForce = train.CurrentForce;
        ForceApplicationResult forceApplicationResult = train.ApplyForce(_force);

        if (forceApplicationResult is ForceApplicationResult.Failure failureForceApplication)
        {
            return new MoveResult.Failure(failureForceApplication.Message);
        }

        MoveResult result = train.CalculateTimeForDistance(_length);
        train.ApplyForce(originalForce);

        return result;
    }
}