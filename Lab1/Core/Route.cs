using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Core;

public record Route
{
    private readonly List<IRouteSegment> _segments;

    private readonly SpeedObject _maxAllowedSpeed;

    public Route(IEnumerable<IRouteSegment> segments, SpeedObject maxAllowedSpeed)
    {
        _segments = segments.ToList();
        _maxAllowedSpeed = maxAllowedSpeed;
    }

    public RouteResult PassRoute(ITrain train)
    {
        var totalTime = new TimeObject(0);

        foreach (IRouteSegment segment in _segments)
        {
            MoveResult segmentResult = segment.PassRouteSegment(train);

            if (segmentResult is MoveResult.Failure failureSegmentResult)
            {
                return new RouteResult.Failure($"Failed: {failureSegmentResult.Message}");
            }

            TimeObject segmentTime = ((MoveResult.Success)segmentResult).Time;

            totalTime = totalTime.Plus(segmentTime);
        }

        if (train.Speed.IsMore(_maxAllowedSpeed))
        {
            return new RouteResult.Failure("Train speed exceeds route limit");
        }

        return new RouteResult.Success(totalTime);
    }
}