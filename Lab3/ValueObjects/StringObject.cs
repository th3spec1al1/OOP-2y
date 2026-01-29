namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record StringObject
{
    public string Value { get; }

    public StringObject(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("String cannot be null or empty");

        Value = value;
    }
}