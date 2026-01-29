using Itmo.ObjectOrientedProgramming.Lab2.Core;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archive;

public class ArchiverAddressee : IAddressee
{
    private readonly IArchiver _archiver;

    public ArchiverAddressee(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public ReceivedMessageResult ReceiveMessage(Message message)
    {
        _archiver.Archive(message);

        return new ReceivedMessageResult.Success();
    }
}