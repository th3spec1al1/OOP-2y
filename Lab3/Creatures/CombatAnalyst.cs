using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : Creature
{
    public CombatAnalyst(AttackObject attack, HealthObject health)
        : base(attack, health) { }

    public override void AttackTarget(ICreature target)
    {
        Attack = Attack.Plus(2);
        target.TakeDamage(this);
    }

    public override ICreature Clone()
    {
        return new CombatAnalyst(Attack, Health);
    }
}