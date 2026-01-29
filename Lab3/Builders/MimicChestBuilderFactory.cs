using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class MimicChestBuilderFactory : CreatureBuilderFactory
{
    public override CreatureBuilder CreateBuilder()
    {
        AttackObject attack = new(1);
        HealthObject health = new(1);

        return new MimicChestBuilder()
            .FeatureConfiguration(attack, health);
    }
}