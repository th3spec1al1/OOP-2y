using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ViciousFighterBuilderFactory : CreatureBuilderFactory
{
    public override CreatureBuilder CreateBuilder()
    {
        AttackObject attack = new(1);
        HealthObject health = new(6);

        return new ViciousFighterBuilder()
            .FeatureConfiguration(attack, health);
    }
}