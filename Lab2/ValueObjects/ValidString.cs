namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record ValidString
{
    public string Value { get; }

    public ValidString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("String cannot be null or empty");

        Value = value;
    }
}