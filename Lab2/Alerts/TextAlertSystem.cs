using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Alerts;

public class TextAlertSystem : IAlertSystem
{
    private readonly ValidString _alertMessage;

    public TextAlertSystem(string alertMessage)
    {
        _alertMessage = new ValidString(alertMessage);
    }

    public void RaiseAlert()
    {
        Console.WriteLine($"ALERT: {_alertMessage}");
    }
}