using Itmo.ObjectOrientedProgramming.Lab1.Core;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Interfaces;

public interface IRouteSegment
{
    MoveResult PassRouteSegment(ITrain train);
}