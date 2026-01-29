using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;

public class MagicShieldApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new CreatureWithMagicShieldModifier(creature);
    }
}