using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

public interface ICreature
{
    AttackObject Attack { get; }

    HealthObject Health { get; }

    bool IsAlive { get; }

    bool CanAttack { get; }

    void AttackTarget(ICreature target);

    void TakeDamage(ICreature attacker);

    ICreature Clone();

    void IncreaseAttack(AttackObject bonus);

    void IncreaseHealth(HealthObject bonus);

    void SwapStats();
}