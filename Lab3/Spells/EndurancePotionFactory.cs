using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotionFactory : SpellFactory
{
    public override ISpell Create()
    {
        return new EndurancePotion();
    }
}