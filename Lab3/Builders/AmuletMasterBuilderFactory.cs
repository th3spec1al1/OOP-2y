using Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterBuilderFactory : CreatureBuilderFactory
{
    public override CreatureBuilder CreateBuilder()
    {
        AttackObject attack = new(5);
        HealthObject health = new(2);

        return new AmuletMasterBuilder()
            .WithModifier(new MagicShieldApplierFactory())
            .WithModifier(new DoubleStrikeApplierFactory())
            .FeatureConfiguration(attack, health);
    }
}