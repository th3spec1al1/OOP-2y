using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CountlessHorrorBuilderFactory : CreatureBuilderFactory
{
    public override CreatureBuilder CreateBuilder()
    {
        AttackObject attack = new(4);
        HealthObject health = new(4);

        return new CountlessHorrorBuilder()
            .FeatureConfiguration(attack, health);
    }
}