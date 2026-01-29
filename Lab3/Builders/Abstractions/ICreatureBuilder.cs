using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;

public interface ICreatureBuilder
{
    ICreature Build();
}