using Itmo.ObjectOrientedProgramming.Lab2.Core;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archive;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _archiveMessages = [];

    public IReadOnlyList<Message> ArchivedMessages => _archiveMessages.AsReadOnly();

    public void Archive(Message message)
    {
        _archiveMessages.Add(message);
    }
}