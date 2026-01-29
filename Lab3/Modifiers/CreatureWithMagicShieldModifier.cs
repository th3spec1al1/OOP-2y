using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class CreatureWithMagicShieldModifier : ICreature
{
    private readonly ICreature _creature;
    private bool _isActive;

    public CreatureWithMagicShieldModifier(ICreature creature, bool? isActive = null)
    {
        _creature = creature;
        _isActive = isActive ?? true;
    }

    public AttackObject Attack => _creature.Attack;

    public HealthObject Health => _creature.Health;

    public bool IsAlive => _creature.IsAlive;

    public bool CanAttack => _creature.CanAttack;

    public void AttackTarget(ICreature target) => _creature.AttackTarget(target);

    public void TakeDamage(ICreature attacker)
    {
        if (_isActive)
        {
            _isActive = false;
            return;
        }

        _creature.TakeDamage(attacker);
    }

    public ICreature Clone() => new CreatureWithMagicShieldModifier(_creature.Clone(), _isActive);

    public void IncreaseAttack(AttackObject bonus) => _creature.IncreaseAttack(bonus);

    public void IncreaseHealth(HealthObject bonus) => _creature.IncreaseHealth(bonus);

    public void SwapStats() => _creature.SwapStats();
}