using Itmo.ObjectOrientedProgramming.Lab2.Core;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Logging;

public class LoggingAddressee : IAddressee
{
    private readonly IAddressee _recipient;
    private readonly ILogger _logger;

    public LoggingAddressee(IAddressee recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public ReceivedMessageResult ReceiveMessage(Message message)
    {
        ReceivedMessageResult result = _recipient.ReceiveMessage(message);

        if (result is ReceivedMessageResult.Success)
        {
            _logger.Log($"Message received." +
                        $"\nMessage Title: {message.Title.Value} \nMessage Body: {message.Body.Value}");
        }
        else if (result is ReceivedMessageResult.WithoutKeywords)
        {
            _logger.Log($"Message not received, because message without keywords." +
                        $"\nMessage Title: {message.Title.Value} \nMessage Body: {message.Body.Value}");
        }
        else if (result is ReceivedMessageResult.LowImportance)
        {
            _logger.Log($"Message not received, because low importance." +
                        $"\nMessage Title: {message.Title.Value} \nMessage Body: {message.Body.Value}");
        }
        else if (result is ReceivedMessageResult.Failure)
        {
            _logger.Log($"Message not received." +
                        $"\nMessage Title: {message.Title.Value} \nMessage Body: {message.Body.Value}");
        }

        return result;
    }
}