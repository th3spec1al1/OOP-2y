using Itmo.ObjectOrientedProgramming.Lab2.Core;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archive;

public interface IArchiver
{
    void Archive(Message message);
}