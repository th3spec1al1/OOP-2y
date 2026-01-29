namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;

public class DoubleStrikeApplierFactory : ModifierApplierFactory
{
    public override IModifierApplier Create()
    {
        return new DoubleStrikeApplier();
    }
}