namespace Itmo.ObjectOrientedProgramming.Lab2.Alerts;

public class SoundAlertSystem : IAlertSystem
{
    public void RaiseAlert()
    {
        Console.Beep();
    }
}