using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ViciousFighterBuilder : CreatureBuilder
{
    protected override ICreature CreateCreature(AttackObject attack, HealthObject health)
    {
        return new ViciousFighter(attack, health);
    }
}