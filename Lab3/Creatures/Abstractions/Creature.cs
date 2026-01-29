using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

public abstract class Creature : ICreature
{
    public AttackObject Attack { get; protected set; }

    public HealthObject Health { get; protected set; }

    public bool IsAlive => Health.IsPositive;

    public bool CanAttack => Attack.IsPositive;

    private AttackObject DefaultAttack { get; set; }

    private HealthObject DefaultHealth { get; set; }

    protected Creature(AttackObject attack, HealthObject health)
    {
        DefaultAttack = attack;
        DefaultHealth = health;
        Attack = DefaultAttack;
        Health = DefaultHealth;
    }

    public virtual void AttackTarget(ICreature target)
    {
        target.TakeDamage(this);
    }

    public virtual void TakeDamage(ICreature attacker)
    {
        Health = Health.Minus(attacker.Attack);
    }

    public abstract ICreature Clone();

    public virtual void IncreaseAttack(AttackObject bonus)
    {
        DefaultAttack = DefaultAttack.Plus(bonus);
        Attack = DefaultAttack;
    }

    public virtual void IncreaseHealth(HealthObject bonus)
    {
        DefaultHealth = DefaultHealth.Plus(bonus);
        Health = DefaultHealth;
    }

    public virtual void SwapStats()
    {
        (Attack, Health) = (Health.ToAttack(), Attack.ToHealth());
    }
}