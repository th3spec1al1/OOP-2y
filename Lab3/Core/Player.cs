using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Core;

public class Player
{
    public StringObject Name { get; }

    public PlayerTable Table { get; }

    public Player(StringObject name, PlayerTable table)
    {
        Name = name;
        Table = table;
    }
}