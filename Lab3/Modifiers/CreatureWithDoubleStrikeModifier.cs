using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class CreatureWithDoubleStrikeModifier : ICreature
{
    private readonly ICreature _creature;

    public CreatureWithDoubleStrikeModifier(ICreature creature)
    {
        _creature = creature;
    }

    public AttackObject Attack => _creature.Attack;

    public HealthObject Health => _creature.Health;

    public bool IsAlive => _creature.IsAlive;

    public bool CanAttack => _creature.CanAttack;

    public void AttackTarget(ICreature target)
    {
        _creature.AttackTarget(target);

        if (target.IsAlive)
        {
            _creature.AttackTarget(target);
        }
    }

    public void TakeDamage(ICreature attacker) => _creature.TakeDamage(attacker);

    public ICreature Clone() => new CreatureWithDoubleStrikeModifier(_creature.Clone());

    public void IncreaseAttack(AttackObject bonus) => _creature.IncreaseAttack(bonus);

    public void IncreaseHealth(HealthObject bonus) => _creature.IncreaseHealth(bonus);

    public void SwapStats() => _creature.SwapStats();
}