using Itmo.ObjectOrientedProgramming.Lab1.Core;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public record RegularMagneticPath : IRouteSegment
{
    private readonly LengthObject _length;

    public RegularMagneticPath(LengthObject length)
    {
        _length = length;
    }

    public MoveResult PassRouteSegment(ITrain train)
    {
        return train.CalculateTimeForDistance(_length);
    }
}