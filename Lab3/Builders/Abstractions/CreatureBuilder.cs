using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Appliers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.Abstractions;

public abstract class CreatureBuilder : ICreatureBuilder
{
    private readonly List<IModifierApplier> _modifiers = [];
    private AttackObject? _attack;
    private HealthObject? _health;

    public CreatureBuilder FeatureConfiguration(AttackObject attack, HealthObject health)
    {
        _attack = attack;
        _health = health;
        return this;
    }

    public CreatureBuilder WithModifier(ModifierApplierFactory modifierFactory)
    {
        IModifierApplier modifier = modifierFactory.Create();
        _modifiers.Add(modifier);
        return this;
    }

    public ICreature Build()
    {
        if (_health is null || _attack is null)
            throw new ArgumentException("Stats should not be null");

        ICreature creature = CreateCreature(_attack, _health);

        foreach (IModifierApplier modifier in _modifiers)
        {
            creature = modifier.Apply(creature);
        }

        return creature;
    }

    protected abstract ICreature CreateCreature(AttackObject attack, HealthObject health);
}