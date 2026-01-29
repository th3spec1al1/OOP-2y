using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ViciousFighter : Creature
{
    public ViciousFighter(AttackObject attack, HealthObject health) : base(attack, health) { }

    public override void TakeDamage(ICreature attacker)
    {
        Health = Health.Minus(attacker.Attack);
        if (IsAlive)
        {
            Attack = Attack.Multiplication(2);
        }
    }

    public override ICreature Clone()
    {
        return new ViciousFighter(Attack, Health);
    }
}