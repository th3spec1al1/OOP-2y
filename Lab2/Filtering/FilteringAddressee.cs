using Itmo.ObjectOrientedProgramming.Lab2.Core;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Filtering;

public class FilteringAddressee : IAddressee
{
    private readonly IAddressee _recipient;
    private readonly MessageImportance _minImportance;

    public FilteringAddressee(IAddressee recipient, MessageImportance minImportance)
    {
        _recipient = recipient;
        _minImportance = minImportance;
    }

    public ReceivedMessageResult ReceiveMessage(Message message)
    {
        if (message.Importance >= _minImportance)
        {
            ReceivedMessageResult result = _recipient.ReceiveMessage(message);
            return result;
        }

        return new ReceivedMessageResult.LowImportance();
    }
}