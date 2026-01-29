namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record HealthObject(int Value)
{
    public bool IsPositive => Value > 0;

    public bool IsNegative => Value < 0;

    public bool IsZero => Value == 0;

    public HealthObject Plus(HealthObject other)
    {
        return new HealthObject(Value + other.Value);
    }

    public HealthObject Minus(AttackObject attack)
    {
        return new HealthObject(Value - attack.Value);
    }

    public bool IsMore(HealthObject other)
    {
        return Value > other.Value;
    }

    public AttackObject ToAttack()
    {
        return new AttackObject(Value);
    }

    public static HealthObject Max(HealthObject first, HealthObject second)
    {
        return first.IsMore(second) ? first : second;
    }
}