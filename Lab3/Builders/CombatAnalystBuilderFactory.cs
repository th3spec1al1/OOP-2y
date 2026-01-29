using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CombatAnalystBuilderFactory : CreatureBuilderFactory
{
    public override CreatureBuilder CreateBuilder()
    {
        AttackObject attack = new(2);
        HealthObject health = new(4);

        return new CombatAnalystBuilder()
            .FeatureConfiguration(attack, health);
    }
}