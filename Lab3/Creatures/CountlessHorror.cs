using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CountlessHorror : Creature
{
    private bool _regeneration = false;

    public CountlessHorror(AttackObject attack, HealthObject health)
        : base(attack, health) { }

    public override void TakeDamage(ICreature attacker)
    {
        Health = Health.Minus(attacker.Attack);
        if ((Health.IsNegative || Health.IsZero) && !_regeneration)
        {
            Health = new HealthObject(1);
            _regeneration = true;
        }
    }

    public override ICreature Clone()
    {
        return new CountlessHorror(Attack, Health);
    }
}