using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;

public interface ISpell
{
    ICreature Apply(ICreature creature);
}