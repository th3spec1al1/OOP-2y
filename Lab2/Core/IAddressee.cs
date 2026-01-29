using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Core;

public interface IAddressee
{
    ReceivedMessageResult ReceiveMessage(Message message);
}