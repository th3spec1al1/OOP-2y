using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Core;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _recipients = [];

    public void AddAddressee(IAddressee recipient)
    {
        _recipients.Add(recipient);
    }

    public ReceivedMessageResult ReceiveMessage(Message message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            ReceivedMessageResult result = recipient.ReceiveMessage(message);

            if (result is ReceivedMessageResult.Failure)
            {
                return new ReceivedMessageResult.Failure();
            }
        }

        return new ReceivedMessageResult.Success();
    }
}