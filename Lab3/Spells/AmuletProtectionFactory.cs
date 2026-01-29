using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class AmuletProtectionFactory : SpellFactory
{
    public override ISpell Create()
    {
        return new AmuletProtection();
    }
}