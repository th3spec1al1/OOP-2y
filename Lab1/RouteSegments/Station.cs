using Itmo.ObjectOrientedProgramming.Lab1.Core;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public record Station : IRouteSegment
{
    private readonly TimeObject _timeForBoard;

    private readonly TimeObject _timeForDisembark;

    private readonly SpeedObject _maxAllowedSpeed;

    public Station(TimeObject timeForBoard, TimeObject timeForDisembark, SpeedObject maxAllowedSpeed)
    {
        _timeForBoard = timeForBoard;
        _timeForDisembark = timeForDisembark;
        _maxAllowedSpeed = maxAllowedSpeed;
    }

    public MoveResult PassRouteSegment(ITrain train)
    {
        if (train.Speed.IsMore(_maxAllowedSpeed))
        {
            return new MoveResult.Failure("Train speed exceeds station limit");
        }

        TimeObject totalTime = _timeForBoard.Plus(_timeForDisembark);

        if (train.Speed.IsZero())
        {
            return new MoveResult.Success(totalTime);
        }

        var requiredForce = ForceObject.CalculateForce(train.Speed, train.Weight);

        if (!train.MaxForce.CanApply(requiredForce))
        {
            return new MoveResult.Failure("Required force on station is more than train's max force");
        }

        return new MoveResult.Success(totalTime);
    }
}