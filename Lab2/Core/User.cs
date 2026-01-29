using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Core;

public class User
{
    public long Id { get; }

    public ValidString Name { get; }

    private readonly Dictionary<Message, ReadStatus> _messages = [];

    public User(long id, string name)
    {
        Id = id;
        Name = new ValidString(name);
    }

    public IReadOnlyDictionary<Message, ReadStatus> Messages => _messages.AsReadOnly();

    public ReceivedMessageResult SendMessage(Message message)
    {
        _messages[message] = ReadStatus.Unread;
        return new ReceivedMessageResult.Success();
    }

    public void MarkAsRead(Message message)
    {
        if (!_messages.TryGetValue(message, out ReadStatus value))
        {
            throw new ArgumentException("Message not found");
        }

        if (_messages[message] == ReadStatus.Read)
        {
            throw new ArgumentException("Message already read");
        }

        _messages[message] = ReadStatus.Read;
    }

    public bool IsMessageRead(Message message)
    {
        return _messages.ContainsKey(message) && _messages[message] == ReadStatus.Read;
    }
}