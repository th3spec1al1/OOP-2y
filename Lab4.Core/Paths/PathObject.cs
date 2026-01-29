using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public class PathObject
{
    private const char Separator = '/';

    private readonly List<ComponentNameObject> _value = [];

    public IReadOnlyList<ComponentNameObject> Value => _value.AsReadOnly();

    public PathObject(string? path = null)
    {
        if (path == null) return;
        string[] splitPath = path.Split(Separator);
        foreach (string pathPart in splitPath)
        {
            if (pathPart == "..")
            {
                if (_value.Count > 0)
                {
                    _value.RemoveAt(_value.Count - 1);
                }
                else
                {
                    _value.Add(new ComponentNameObject(pathPart));
                }
            }
            else if (pathPart == ".")
            {
                continue;
            }
            else
            {
                _value.Add(new ComponentNameObject(pathPart));
            }
        }
    }

    private PathObject(IReadOnlyList<ComponentNameObject> value)
    {
        _value = value.ToList();
    }

    public PathObject GetParentPath()
    {
        if (_value.Count == 0) return new PathObject();

        PathObject res = Copy();
        res._value.RemoveAt(_value.Count - 1);
        return res;
    }

    public PathObject Plus(PathObject other)
    {
        PathObject res = Copy();
        foreach (ComponentNameObject obj in other.Value)
            res._value.Add(obj);
        return res;
    }

    private PathObject Copy()
    {
        return new PathObject(_value);
    }
}