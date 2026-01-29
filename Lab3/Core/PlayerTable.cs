using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Abstractions;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Core;

public class PlayerTable
{
    private readonly List<ICreature> _creatures;

    private PlayerTable(List<ICreature> creatures)
    {
        _creatures = creatures;
    }

    public IReadOnlyList<ICreature> Creatures => _creatures.AsReadOnly();

    public void ApplyToCreature(int creatureIndexOnTable, SpellFactory spellFactory)
    {
        if (creatureIndexOnTable < 0 || creatureIndexOnTable >= _creatures.Count)
            throw new ArgumentException("Invalid creature index");

        ISpell spell = spellFactory.Create();
        _creatures[creatureIndexOnTable] = spell.Apply(_creatures[creatureIndexOnTable]);
    }

    public void ApplyToCreature(int creatureIndexOnTable, ModifierApplierFactory modifierFactory)
    {
        if (creatureIndexOnTable < 0 || creatureIndexOnTable >= _creatures.Count)
            throw new ArgumentException("Invalid creature index");

        IModifierApplier applier = modifierFactory.Create();
        _creatures[creatureIndexOnTable] = applier.Apply(_creatures[creatureIndexOnTable]);
    }

    public ICreature? GetAttacker()
    {
        var attackers = _creatures.Where(c => c.IsAlive && c.CanAttack).ToList();
        ICreature? attacker = RandomCreature(attackers);

        return attacker;
    }

    public ICreature? GetTarget()
    {
        var targets = _creatures.Where(c => c.IsAlive).ToList();
        ICreature? target = RandomCreature(targets);

        return target;
    }

    public PlayerTable Clone()
    {
        return new PlayerTableBuilder().AddCreatures(_creatures).Build();
    }

    private ICreature? RandomCreature(IEnumerable<ICreature> creatures)
    {
        var creaturesList = creatures.ToList();

        if (creaturesList.Count == 0)
            return null;

        int randomIndex = RandomNumberGenerator.GetInt32(creaturesList.Count);
        return creaturesList[randomIndex];
    }

    public class PlayerTableBuilder
    {
        private const int MaxCreatures = 7;
        private readonly List<ICreature> _creatures = [];

        public PlayerTableBuilder AddCreature(ICreature creature)
        {
            if (_creatures.Count >= MaxCreatures)
                throw new ArgumentException("Table is full");

            _creatures.Add(creature.Clone());
            return this;
        }

        public PlayerTableBuilder AddCreatures(IEnumerable<ICreature> creatures)
        {
            foreach (ICreature creature in creatures)
            {
                if (_creatures.Count >= MaxCreatures)
                    throw new ArgumentException("Table is full");
                _creatures.Add(creature.Clone());
            }

            return this;
        }

        public PlayerTable Build()
        {
            return new PlayerTable(_creatures);
        }
    }
}