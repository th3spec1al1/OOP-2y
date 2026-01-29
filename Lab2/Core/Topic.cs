using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Core;

public class Topic
{
    public ValidString Name { get; }

    private readonly List<IAddressee> _recipients = [];

    public Topic(string name)
    {
        Name = new ValidString(name);
    }

    public void AddRecipient(IAddressee recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}