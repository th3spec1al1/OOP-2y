namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

public class CommandTokenIterator
{
    private readonly string[] _tokens;
    private int _currentIndex = -1;

    public CommandTokenIterator(string input)
    {
        _tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    public string Current
    {
        get
        {
            if (_currentIndex >= _tokens.Length) throw new InvalidOperationException("No current");
            return _tokens[_currentIndex];
        }
    }

    public bool MoveNext()
    {
        if (_currentIndex + 1 >= _tokens.Length) return false;
        _currentIndex += 1;
        return true;
    }
}