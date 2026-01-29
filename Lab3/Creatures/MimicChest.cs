using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : Creature
{
    public MimicChest(AttackObject attack, HealthObject health)
        : base(attack, health) { }

    public override void AttackTarget(ICreature target)
    {
        Attack = AttackObject.Max(Attack, target.Attack);
        Health = HealthObject.Max(Health, target.Health);

        target.TakeDamage(this);
    }

    public override ICreature Clone()
    {
        return new MimicChest(Attack, Health);
    }
}