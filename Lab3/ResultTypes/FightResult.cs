namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record FightResult
{
    private FightResult() { }

    public sealed record FirstPlayerWin : FightResult;

    public sealed record SecondPlayerWin : FightResult;

    public sealed record Draw : FightResult;

    public sealed record DrawDueLongPlay : FightResult;
}