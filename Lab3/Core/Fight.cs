using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Core;

public class Fight
{
    private const int MaxTurns = 100;

    private readonly PlayerTable _firstTable;
    private readonly PlayerTable _secondTable;

    public Fight(PlayerTable table1, PlayerTable table2)
    {
        _firstTable = table1.Clone();
        _secondTable = table2.Clone();
    }

    public FightResult HaveFight()
    {
        FightResult result = FightSimulation();
        return result;
    }

    private FightResult FightSimulation()
    {
        bool turn = true;

        for (int turnNumber = 0; turnNumber < MaxTurns; turnNumber++)
        {
            FightResult? result = turn ? Attack(_firstTable, _secondTable) : Attack(_secondTable, _firstTable);

            if (result != null)
                return result;

            turn = !turn;
        }

        return new FightResult.DrawDueLongPlay();
    }

    private FightResult? Attack(PlayerTable attackerTable, PlayerTable defenderTable)
    {
        ICreature? attacker = attackerTable.GetAttacker();
        ICreature? target = defenderTable.GetTarget();

        if (attacker != null && target == null)
            return attackerTable == _firstTable ? new FightResult.FirstPlayerWin() : new FightResult.SecondPlayerWin();

        if (attacker == null && target == null)
            return new FightResult.Draw();

        if (attacker != null && target != null)
            attacker.AttackTarget(target);

        return null;
    }
}