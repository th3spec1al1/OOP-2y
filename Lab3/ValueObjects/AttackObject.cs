namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record AttackObject(int Value)
{
    public bool IsPositive => Value > 0;

    public AttackObject Plus(int number)
    {
        return new AttackObject(Value + number);
    }

    public AttackObject Plus(AttackObject other)
    {
        return new AttackObject(Value + other.Value);
    }

    public AttackObject Multiplication(int number)
    {
        return new AttackObject(Value * number);
    }

    public bool IsMore(AttackObject other)
    {
        return Value > other.Value;
    }

    public HealthObject ToHealth()
    {
        return new HealthObject(Value);
    }

    public static AttackObject Max(AttackObject first, AttackObject second)
    {
        return first.IsMore(second) ? first : second;
    }
}