using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;

public class DoubleStrikeApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new CreatureWithDoubleStrikeModifier(creature);
    }
}