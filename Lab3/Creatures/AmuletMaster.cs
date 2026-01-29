using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : Creature
{
    public AmuletMaster(AttackObject attack, HealthObject health)
        : base(attack, health) { }

    public override ICreature Clone()
    {
        return new AmuletMaster(Attack, Health);
    }
}