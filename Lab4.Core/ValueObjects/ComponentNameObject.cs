namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

public record ComponentNameObject
{
    public string Value { get; }

    public ComponentNameObject(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Contains('/', StringComparison.Ordinal))
        {
            throw new ArgumentException("Name cannot be null or empty", nameof(value));
        }

        Value = value;
    }

    public bool IsEqual(ComponentNameObject other)
    {
        return Value == other.Value;
    }
}