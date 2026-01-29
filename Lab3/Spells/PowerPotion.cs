using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    private readonly AttackObject _bonus = new AttackObject(5);

    public ICreature Apply(ICreature creature)
    {
        creature.IncreaseAttack(_bonus);
        return creature;
    }
}