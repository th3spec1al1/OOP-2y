using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class AmuletProtection : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        return new CreatureWithMagicShieldModifier(creature);
    }
}