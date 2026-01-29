namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;

public class MagicShieldApplierFactory : ModifierApplierFactory
{
    public override IModifierApplier Create()
    {
        return new MagicShieldApplier();
    }
}