using Itmo.ObjectOrientedProgramming.Lab2.Core;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Alerts;

public class AlertingAddressee : IAddressee
{
    private readonly IAlertSystem _alertSystem;
    private readonly IReadOnlyList<string> _keywords;

    public AlertingAddressee(IAlertSystem alertSystem, IReadOnlyList<string> keywords)
    {
        _alertSystem = alertSystem;
        _keywords = keywords;
    }

    public ReceivedMessageResult ReceiveMessage(Message message)
    {
        bool hasKeyword = _keywords.Any(word =>
            message.Title.Value.Contains(word, StringComparison.OrdinalIgnoreCase) ||
            message.Body.Value.Contains(word, StringComparison.OrdinalIgnoreCase));

        if (!hasKeyword) return new ReceivedMessageResult.WithoutKeywords();
        _alertSystem.RaiseAlert();
        return new ReceivedMessageResult.Success();
    }
}