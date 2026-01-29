using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    private readonly HealthObject _bonus = new HealthObject(5);

    public ICreature Apply(ICreature creature)
    {
        creature.IncreaseHealth(_bonus);
        return creature;
    }
}