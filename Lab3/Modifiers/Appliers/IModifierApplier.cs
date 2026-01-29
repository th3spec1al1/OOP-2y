using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;

public interface IModifierApplier
{
    ICreature Apply(ICreature creature);
}